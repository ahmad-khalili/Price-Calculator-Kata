using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public static class Discount
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

    public static Constants.TaxPrecedence TaxPrecedence = Constants.TaxPrecedence.Before;

    public static bool HasDiscount()
    {
        if (Percentage <= 0) return false;
        return true;
    }

    public static bool IsBeforeTax()
    {
        var isBefore = TaxPrecedence.Equals(Constants.TaxPrecedence.Before);
        if (isBefore) return true;
        return false;
    }
}