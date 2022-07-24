using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class DiscountCalculator
{
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
    
    public static float CalculateDiscountAmount(float price)
    {
        var discount = DiscountPercentage / 100F;
        var discountAmount = price * discount;
        return discountAmount;
    }
    
    public static void PrintDiscountAmount(Product product)
    {
        if (DiscountPercentage > 0)
        {
            var discountAmount = CalculateDiscountAmount(product.Price);
            Console.WriteLine($"Discount Amount: ${discountAmount.SetPrecision(Constants.DecimalPrecision)}");
        }
    }
}