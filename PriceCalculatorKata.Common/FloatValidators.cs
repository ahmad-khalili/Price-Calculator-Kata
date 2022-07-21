namespace PriceCalculatorKata.Common;

public static class FloatValidators
{
    public static bool FloatValid(this float source)
    {
        if (source <= 0) return false;
        return true;
    }
}