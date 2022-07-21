namespace PriceCalculatorKata.Common;

public static class IntValidators
{
    public static bool IsValid(this int source)
    {
        if (source <= 0) return false;
        return true;
    }
}