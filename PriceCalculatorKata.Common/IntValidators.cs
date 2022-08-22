namespace PriceCalculatorKata.Common;

public static class IntValidators
{
    public static bool IsPositive(this int source)
    {
        if (source <= 0) return false;
        return true;
    }
}