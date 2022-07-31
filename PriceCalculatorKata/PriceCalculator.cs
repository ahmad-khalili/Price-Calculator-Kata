using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    private static float _totalDiscountAmount;
    private static Cap _cap;
    public static void DisplayPrice(Product product, Constants.CombineMethod combineMethod)
    {
        var totalPrice = CalculateTotalPrice(product, combineMethod);
            var discountToPrint = DiscountCalculator.HasDiscount() ? $"%{DiscountCalculator.Percentage}" 
            : "no";
        var specialDiscountToPrint = 
            SpecialDiscountCalculator.SpecialDiscountExists(product.UniversalProductCode)
            ? $"%{SpecialDiscountCalculator.GetSpecialDiscount(product.UniversalProductCode)}"
            : "No";
        var currency = product.GetCurrency();
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"{product.Price.SetPrecision(Constants.DecimalPrecision)} {currency} before tax and discount " +
                          $"and {totalPrice.SetPrecision(Constants.DecimalPrecision)} {currency} " +
                          $"after %{TaxCalculator.Percentage} tax and {discountToPrint} discount / " +
                          $"{specialDiscountToPrint} special discount");
        
        product.PrintExpenses();
        PrintTotalDiscountAmount(product);
    }

    private static float CalculateTotalPrice(Product product, Constants.CombineMethod combineMethod)
    {
        float universalDiscountAmount = 0;
        float specialDiscountAmount = 0;
        
        var productCode = product.UniversalProductCode;
        
        float remainingPriceDiscounts = product.Price;
        float remainingPriceTax = product.Price;
        
        var isAdditive = combineMethod.Equals(Constants.CombineMethod.Additive);

        if (SpecialDiscountCalculator.SpecialDiscountExists(productCode))
        {
            specialDiscountAmount =
                SpecialDiscountCalculator.CalculateSpecialDiscountAmount(productCode, remainingPriceDiscounts);

            if (!isAdditive) remainingPriceDiscounts -= specialDiscountAmount;

            if (SpecialDiscountCalculator.IsBeforeTax(productCode)) remainingPriceTax -= specialDiscountAmount;
        }
        
        if (DiscountCalculator.HasDiscount())
        {
            universalDiscountAmount = DiscountCalculator.CalculateDiscountAmount(remainingPriceDiscounts);

            if (!isAdditive) remainingPriceDiscounts -= universalDiscountAmount;

            if (DiscountCalculator.IsBeforeTax()) remainingPriceTax -= universalDiscountAmount;
        }

        var taxAmount = TaxCalculator.CalculateTaxAmount(remainingPriceTax);
        
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
        
        return totalPrice;
    }

    private static void PrintTotalDiscountAmount(Product product)
    {
        var currency = product.GetCurrency();
        Console.WriteLine($"Total Discount Amount: {_totalDiscountAmount.SetPrecision(Constants.DecimalPrecision)} {currency}");
    }

    public static void SetCap(float amount, Constants.ValueType valueType)
    {
        _cap.Amount = amount;
        _cap.ValueType = valueType;
    }
}