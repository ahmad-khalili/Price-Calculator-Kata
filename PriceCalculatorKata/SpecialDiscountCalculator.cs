﻿namespace PriceCalculatorKata;

public static class SpecialDiscountCalculator
{
    private static Dictionary<string, SpecialDiscount> _specialDiscounts = new();

    public static void AddSpecialDiscount(string productCode, int discountPercentage, Constants.TaxPrecedence taxPrecedence)
    {
        var discountToAdd = new SpecialDiscount
        {
            Percentage = discountPercentage,
            TaxPrecedence = taxPrecedence
        };
        _specialDiscounts.Add(productCode, discountToAdd);
    }
    
    public static float CalculateSpecialDiscountAmount(string productCode, float price)
    {
        var specialDiscount = GetSpecialDiscount(productCode);
        
        if (specialDiscount.Equals(0)) return 0;
        
        var discount = specialDiscount / 100F;
        var discountAmount = discount * price;
        return discountAmount;
    }

    public static bool SpecialDiscountExists(string productCode)
    {
        return _specialDiscounts.ContainsKey(productCode);
    }
    
    public static int GetSpecialDiscount(string productCode)
    {
        _specialDiscounts.TryGetValue(productCode, out var discount);
        return discount.Percentage;
    }

    public static bool IsBeforeTax(string productCode)
    {
        if (!SpecialDiscountExists(productCode)) return false;
        var isBefore = _specialDiscounts[productCode].TaxPrecedence.Equals(Constants.TaxPrecedence.Before);
        if (isBefore) return true;
        return false;
    }
}