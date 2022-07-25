using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public static class Tax
{
    private static int _tax = Constants.DefaultTax;
    public static int Percentage
    {
        get => _tax;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Tax Percentage", $"{value}");
            _tax = value;
        }
    }
}