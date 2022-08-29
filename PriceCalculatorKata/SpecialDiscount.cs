using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class SpecialDiscount
{
    private int _percentage = 0;
    public int Percentage
    {
        get => _percentage;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Discount percentage has to be higher than 0%", $"{value}");
            _percentage = value;
        }
    }
    public Constants.TaxPrecedence TaxPrecedence { get; set; } = Constants.TaxPrecedence.After;
}