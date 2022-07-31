using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public struct Cap
{
    private float _amount;

    public float Amount
    {
        get => _amount;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Capacity value has to be bigger than 0% or 0$", $"{value}");
            _amount = value;
        }
    }
    public Constants.ValueType ValueType { get; set; }

    public bool IsAboveCap(float discounts, Product product)
    {
        if (ValueType.Equals(Constants.ValueType.Percentage))
        {
            var capAmount = Amount * product.Price;
            if (discounts >= capAmount)
                return true;
        }
        else
        {
            if (discounts >= Amount)
                return true;
        }
        return false;
    }
}