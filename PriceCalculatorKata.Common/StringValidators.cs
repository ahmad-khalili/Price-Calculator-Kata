namespace PriceCalculatorKata.Common;

public static class StringValidators
{
    public static bool IsValid(this string? source)
    {
        if (string.IsNullOrWhiteSpace(source)) return false;
        return true;
    }
}