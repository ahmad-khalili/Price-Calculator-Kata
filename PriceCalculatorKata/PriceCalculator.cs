using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class PriceCalculator
{
    private float _taxPercentage = 0.20F;
    public float TaxPercentage
    {
        get => _taxPercentage;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Tax Percentage", $"{value}");
            _taxPercentage = value;
        }
    }

}