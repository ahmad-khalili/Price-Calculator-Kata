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

    public static Dictionary<string, int> SpecialDiscounts = new();

    public static float CalculateDiscountAmount(float price)
    {
        if (DiscountPercentage <= 0) return 0;
        var discount = DiscountPercentage / 100F;
        var discountAmount = price * discount;
        return discountAmount;
    }

    public static void AddSpecialDiscount(string productCode, int specialDiscountPercentage)
    {
        SpecialDiscounts.Add(productCode, specialDiscountPercentage);
    }
    
    public static bool SpecialDiscountExists(Product product)
    {
        var productDiscountsExists = SpecialDiscounts.ContainsKey(product.UniversalProductCode);
        if (SpecialDiscounts.Any() && productDiscountsExists) return true;
        return false;
    }

    public static float CalculateSpecialDiscountAmount(Product product)
    {
        if (!SpecialDiscountExists(product)) return 0;
        var specialDiscount = SpecialDiscounts[product.UniversalProductCode] / 100F;
        var specialDiscountAmount = specialDiscount * product.Price;
        return specialDiscountAmount;
    }

    public static float CalculateTotalDiscountAmount(Product product)
    {
        var universalDiscountAmount = CalculateDiscountAmount(product.Price);
        var specialDiscountAmount = CalculateSpecialDiscountAmount(product);
        var totalDiscountAmount = universalDiscountAmount + specialDiscountAmount;
        return totalDiscountAmount;
    }

    public static void PrintTotalDiscountAmount(Product product)
    {
        var hasDiscounts = SpecialDiscountExists(product) || DiscountPercentage > 0;
        if (hasDiscounts)
        {
            var totalDiscountAmount = CalculateTotalDiscountAmount(product);
            Console.WriteLine($"Total Discount Amount: ${totalDiscountAmount.SetPrecision(Constants.DecimalPrecision)}");
        }
    }
}