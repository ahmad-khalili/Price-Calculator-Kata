using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public static class DiscountCalculator
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

    private static Dictionary<string, int> _specialDiscounts = new();

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

    public static void AddSpecialDiscount(string productCode, int specialDiscountPercentage)
    {
        _specialDiscounts.Add(productCode, specialDiscountPercentage);
    }
    
    public static bool SpecialDiscountExists(Product product)
    {
        var productDiscountsExists = _specialDiscounts.ContainsKey(product.UniversalProductCode);
        if (_specialDiscounts.Any() && productDiscountsExists) return true;
        return false;
    }

    public static float CalculateSpecialDiscountAmount(Product product)
    {
        if (!SpecialDiscountExists(product)) return 0;
        var specialDiscount = _specialDiscounts[product.UniversalProductCode];
        var specialDiscountAmount = specialDiscount * product.Price;
        return specialDiscountAmount;
    }
}