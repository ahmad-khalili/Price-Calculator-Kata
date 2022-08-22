using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    
    public static void DisplayPrice(Product product)
    {
        var totalPrice = CalculateTotalPrice(product);
        var discountToPrint = DiscountCalculator.DiscountPercentage > 0 ? $"%{DiscountCalculator.DiscountPercentage}" 
            : "no";
        var specialDiscountToPrint = DiscountCalculator.SpecialDiscounts.ContainsKey(product.UniversalProductCode)
            ? $"%{DiscountCalculator.SpecialDiscounts[product.UniversalProductCode]}"
            : "no";
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(Constants.DecimalPrecision)} before tax and discount " +
                          $"and ${totalPrice.SetPrecision(Constants.DecimalPrecision)} " +
                          $"after %{TaxCalculator.TaxPercentage} tax and {discountToPrint} discount / " +
                          $"{specialDiscountToPrint} special discount");
        DiscountCalculator.PrintTotalDiscountAmount(product);
    }
    private static float CalculateTotalPrice(Product product)
    {
        var priceAfterTax = TaxCalculator.CalculateTax(product.Price);
        var discountAmount = DiscountCalculator.CalculateDiscountAmount(product.Price);
        var specialDiscountAmount = DiscountCalculator.CalculateSpecialDiscountAmount(product);
        var totalDiscountAmount = discountAmount + specialDiscountAmount;
        var totalPrice = priceAfterTax - totalDiscountAmount;
        return totalPrice;
    }
}