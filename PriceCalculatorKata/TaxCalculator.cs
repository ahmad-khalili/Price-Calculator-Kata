using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class TaxCalculator
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
    
    public static float CalculateTax(float price)
    {
        var tax = TaxPercentage / 100F;
        var taxAmount = price * tax;
        var priceAfterTax = price + taxAmount;
        return priceAfterTax;
    }
}