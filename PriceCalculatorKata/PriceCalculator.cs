using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    private const int DefaultTax = 20;


    private static int _taxPercentage = DefaultTax;
    public static int TaxPercentage
    {
        get => _taxPercentage;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Tax Percentage", $"{value}");
            _taxPercentage = value;
        }
    }
    
    private static int _discountPercentage;
    public static int DiscountPercentage
    {
        get => _discountPercentage;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Discount Amount!", $"{value}");
            _discountPercentage = value;
        }
    }

    public static void DisplayPrice(Product product)
    {
        var tax = TaxPercentage / 100F;
        var addedPrice = product.Price * tax;
        var priceAfterTax = product.Price + addedPrice;
        var decimalPrecision = 2;
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(decimalPrecision)} before tax " +
                          $"and ${priceAfterTax.SetPrecision(decimalPrecision)} after %{TaxPercentage} tax");
    }
}