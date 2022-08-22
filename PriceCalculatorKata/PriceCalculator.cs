using System.Globalization;
using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    
    public static void DisplayPrice(Product product)
    {
        var totalPrice = CalculateTotalPrice(product);
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(Constants.DecimalPrecision)} before tax and discount " +
                          $"and ${totalPrice.SetPrecision(Constants.DecimalPrecision)} " +
                          $"after %{TaxCalculator.TaxPercentage} tax and {GetDiscountAmount()} discount / " +
                          $"{GetSpecialDiscountAmount(product.UniversalProductCode)} special discount");
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

    private static string GetDiscountAmount()
    {
        if (DiscountCalculator.DiscountPercentage > 0)
            return DiscountCalculator.DiscountPercentage.ToString();
        
        return "no";
    }

    private static string GetSpecialDiscountAmount(string universalProductCode)
    {
        if (DiscountCalculator.SpecialDiscounts.TryGetValue(universalProductCode, out var specialDiscountPercentage))
            return specialDiscountPercentage.ToString();

        return "no";
    }
}