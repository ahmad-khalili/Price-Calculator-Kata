using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    private static float _totalDiscountAmount;
    public static void DisplayPrice(Product product)
    {
        var totalPrice = CalculateTotalPrice(product);
        var discountToPrint = DiscountCalculator.HasDiscount() ? $"%{DiscountCalculator.Percentage}" 
            : "no";
        var specialDiscountToPrint = 
            SpecialDiscountCalculator.SpecialDiscountExists(product.UniversalProductCode)
            ? $"%{SpecialDiscountCalculator.GetSpecialDiscount(product.UniversalProductCode)}"
            : "No";
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(Constants.DecimalPrecision)} before tax and discount " +
                          $"and ${totalPrice.SetPrecision(Constants.DecimalPrecision)} " +
                          $"after %{TaxCalculator.Percentage} tax and {discountToPrint} discount / " +
                          $"{specialDiscountToPrint} special discount");
        
        product.PrintExpenses();
        PrintTotalDiscountAmount(product);
    }

    private static float CalculateTotalPrice(Product product)
    {
        float universalDiscountAmount = 0;
        float specialDiscountAmount = 0;
        var productCode = product.UniversalProductCode;
        float remainingPrice = product.Price;

        if (SpecialDiscountCalculator.SpecialDiscountExists(productCode))
        {
            specialDiscountAmount =
                SpecialDiscountCalculator.CalculateSpecialDiscountAmount(productCode, remainingPrice);
            
            if (SpecialDiscountCalculator.IsBeforeTax(productCode)) remainingPrice -= specialDiscountAmount;
        }

        if (DiscountCalculator.HasDiscount())
        {
            universalDiscountAmount = DiscountCalculator.CalculateDiscountAmount(remainingPrice);
            if (DiscountCalculator.IsBeforeTax()) remainingPrice -= universalDiscountAmount;
        }
        
        var taxAmount = TaxCalculator.CalculateTaxAmount(remainingPrice);
        _totalDiscountAmount = specialDiscountAmount + universalDiscountAmount;
        var totalExpenses = ExpenseCalculator.CalculateExpenses(product);
        var totalPrice = product.Price - _totalDiscountAmount + taxAmount + totalExpenses;
        return totalPrice;
    }

    private static void PrintTotalDiscountAmount(Product product)
    {
        Console.WriteLine($"Total Discount Amount: ${_totalDiscountAmount.SetPrecision(Constants.DecimalPrecision)}");
    }
}