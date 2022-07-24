using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    
    public static void DisplayPrice(Product product)
    {
        var totalPrice = CalculateTotalPrice(product.Price);
        var discountToPrint = DiscountCalculator.DiscountPercentage > 0 ? $"%{DiscountCalculator.DiscountPercentage}" 
            : "no";
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(Constants.DecimalPrecision)} before tax and discount" +
                          $"and ${totalPrice.SetPrecision(Constants.DecimalPrecision)} " +
                          $"after %{TaxCalculator.TaxPercentage} tax and {discountToPrint} discount");
        DiscountCalculator.PrintDiscountAmount(product);
    }
    
    private static float CalculateTotalPrice(float price)
    {
        var priceAfterTax = TaxCalculator.CalculateTax(price);
        var discountAmount = DiscountCalculator.CalculateDiscountAmount(price);
        var totalPrice = priceAfterTax - discountAmount;
        return totalPrice;
    }
}