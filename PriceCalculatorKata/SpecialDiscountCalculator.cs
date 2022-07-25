namespace PriceCalculatorKata;

public static class SpecialDiscountCalculator
{
    private static List<SpecialDiscount> _specialDiscounts = new();

    public static void AddSpecialDiscount(string productCode, int percentage, Constants.TaxPrecedence taxPrecedence)
    {
        var discountToAdd = new SpecialDiscount
        {
            DiscountedProductCode = productCode,
            DiscountPercentage = percentage,
            TaxPrecedence = taxPrecedence
        };
        
        _specialDiscounts.Add(discountToAdd);
    }
    
    private static float CalculateSpecialDiscountAmount(string productCode, float price)
    {
        var specialDiscount = GetSpecialDiscount(productCode);
        
        if (specialDiscount.Equals(null)) return 0;
        
        var discountPercentage = specialDiscount.DiscountPercentage;
        var discount = discountPercentage / 100F;
        var discountAmount = discount * price;
        return discountAmount;
    }

    public static float CalculateSpecialDiscount(string productCode, float price)
    {
        var discountAmount = CalculateSpecialDiscountAmount(productCode, price);
        price -= discountAmount;
        return price;
    }

    public static SpecialDiscount GetSpecialDiscount(string productCode)
    {
        var discount = _specialDiscounts.FirstOrDefault(discount => discount.DiscountedProductCode.Equals(productCode));
        return discount;
    }
}