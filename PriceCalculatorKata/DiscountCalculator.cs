using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public static class DiscountCalculator
{
    private static int _percentage;
    public static int Percentage
    {
        get => _percentage;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Discount Amount!", $"{value}");
            _percentage = value;
        }
    }

    public static Constants.TaxPrecedence TaxPrecedence { get; set; } = Constants.TaxPrecedence.After;

    public static bool HasDiscount()
    {
        if (Percentage <= 0) return false;
        return true;
    }
    
    public static bool IsBeforeTax()
    {
        var isBefore = TaxPrecedence.Equals(Constants.TaxPrecedence.Before);
        return isBefore;
    }
    
    public static float CalculateDiscountAmount(float price)
    {
        if (!HasDiscount()) return 0;
        var discount = Percentage / 100F;
        var discountAmount = price * discount;
        return discountAmount;
    }
    
}