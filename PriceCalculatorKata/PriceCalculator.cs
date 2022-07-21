using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;


public static class PriceCalculator
{
    private const int DefaultTax = 20;
    private const int DecimalPrecision = 2;

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
        var totalPrice = CalculateTotalPrice(product.Price);
        Console.WriteLine($"{product.ProductName} Product reported as " +
                          $"${product.Price.SetPrecision(DecimalPrecision)} before tax and discount" +
                          $"and ${totalPrice.SetPrecision(DecimalPrecision)} " +
                          $"after %{TaxPercentage} tax and {DiscountPercentage} discount");
    }

    private static void PrintDiscountAmount(Product product)
    {
        if (DiscountPercentage > 0)
        {
            var discountAmount = CalculateDiscountAmount(product.Price);
            Console.WriteLine($"Discount Amount: ${discountAmount.SetPrecision(DecimalPrecision)}");
        }
    }
    
    private static float CalculateTax(float price)
    {
        var tax = TaxPercentage / 100F;
        var taxAmount = price * tax;
        var priceAfterTax = price + taxAmount;
        return priceAfterTax;
    }

    private static float CalculateDiscountAmount(float price)
    {
        var discount = DiscountPercentage / 100F;
        var discountAmount = price * discount;
        return discountAmount;
    }

    private static float CalculateTotalPrice(float price)
    {
        var priceAfterTax = CalculateTax(price);
        var discountAmount = CalculateDiscountAmount(price);
        var totalPrice = priceAfterTax - discountAmount;
        return totalPrice;
    }
}