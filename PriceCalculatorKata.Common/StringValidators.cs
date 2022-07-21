namespace PriceCalculatorKata.Common;

public static class StringValidators
{
    public static bool StringValid(this string? source)
    {
        if (string.IsNullOrWhiteSpace(source)) return false;
        return true;
    }
}