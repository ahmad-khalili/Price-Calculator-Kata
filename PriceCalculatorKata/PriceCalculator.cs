using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{

    public static void DisplayPrice(Product product)
    {
        var totalPrice = CalculateTotalPrice(product);
        var discountToPrint = Discount.HasDiscount() ? $"%{Discount.Percentage}" 
            : "no";
        var specialDiscountToPrint = SpecialDiscountCalculator.SpecialDiscountExists(product.UniversalProductCode)
            ? $"%{SpecialDiscountCalculator.GetSpecialDiscount(product.UniversalProductCode).DiscountPercentage}"
            : "no";
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(Constants.DecimalPrecision)} before tax and discount " +
                          $"and ${totalPrice.SetPrecision(Constants.DecimalPrecision)} " +
                          $"after %{Tax.Percentage} tax and {discountToPrint} discount / " +
                          $"{specialDiscountToPrint} special discount");
    }
}