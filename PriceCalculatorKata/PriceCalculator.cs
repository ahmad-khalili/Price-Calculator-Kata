using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    private static decimal _totalDiscountAmount;
    private static Cap _cap;
    public static void DisplayPrice(Product product, Constants.CombineMethod combineMethod)
    {
        var totalPrice = CalculateTotalPrice(product, combineMethod);
            var discountToPrint = Discount.HasDiscount() ? $"%{Discount.Percentage}" 
            : "no";
        var specialDiscountToPrint = 
            SpecialDiscountCalculator.SpecialDiscountExists(product.UniversalProductCode!)
            ? $"%{SpecialDiscountCalculator.GetSpecialDiscount(product.UniversalProductCode!)}"
            : "No";
        var currency = product.GetCurrency();
        Console.WriteLine($"{product.Name} product reported as " +
                          $"{product.Price.SetPrecision(Constants.DecimalPrecisionFinal)} {currency} before tax and discount " +
                          $"and {totalPrice.SetPrecision(Constants.DecimalPrecisionFinal)} {currency} " +
                          $"after %{Tax.Percentage} tax and {discountToPrint} discount / " +
                          $"{specialDiscountToPrint} special discount");
        
        product.PrintExpenses();
        PrintTotalDiscountAmount(product);
        Tax.PrintTaxAmount(product);
    }

    private static decimal CalculateTotalPrice(Product product, Constants.CombineMethod combineMethod)
    {
        decimal universalDiscountAmount = 0;
        decimal specialDiscountAmount = 0;
        
        var productCode = product.UniversalProductCode;
        
        decimal remainingPriceDiscounts = product.Price;
        decimal remainingPriceTax = product.Price;
        
        var isAdditive = combineMethod.Equals(Constants.CombineMethod.Additive);

        if (SpecialDiscountCalculator.SpecialDiscountExists(productCode!))
        {
            specialDiscountAmount =
                SpecialDiscountCalculator.CalculateSpecialDiscountAmount(productCode!, remainingPriceDiscounts);

            if (!isAdditive) remainingPriceDiscounts -= specialDiscountAmount;

            if (SpecialDiscountCalculator.IsBeforeTax(productCode!)) remainingPriceTax -= specialDiscountAmount;
        }
        
        if (Discount.HasDiscount())
        {
            universalDiscountAmount = Discount.CalculateDiscountAmount(remainingPriceDiscounts);

            if (!isAdditive) remainingPriceDiscounts -= universalDiscountAmount;

            if (Discount.IsBeforeTax()) remainingPriceTax -= universalDiscountAmount;
        }

        var taxAmount = Tax.CalculateTaxAmount(remainingPriceTax);
        
        _totalDiscountAmount = specialDiscountAmount + universalDiscountAmount;
        
        if (_cap.IsAboveCap(_totalDiscountAmount, product) && _cap.Amount != 0)
        {
            if (_cap.ValueType.Equals(Constants.ValueType.Percentage))
            {
                var discountAmount = _cap.Amount * product.Price;
                _totalDiscountAmount = discountAmount;
            }
            else
            {
                _totalDiscountAmount = _cap.Amount;
            }
        }
        var totalExpenses = ExpenseCalculator.CalculateExpenses(product);
        
        var totalPrice = product.Price - _totalDiscountAmount + taxAmount + totalExpenses;

        return totalPrice.SetPrecision(Constants.DecimalPrecisionOperations);
    }

    private static void PrintTotalDiscountAmount(Product product)
    {
        if (Discount.Percentage > 0)
        {
            var currency = product.GetCurrency();
            Console.WriteLine(
                $"Total Discount Amount: {_totalDiscountAmount.SetPrecision(Constants.DecimalPrecisionFinal)} {currency}");
        }
    }

    public static void SetCap(decimal amount, Constants.ValueType valueType)
    {
        _cap.Amount = amount;
        _cap.ValueType = valueType;
    }
}