using System.Globalization;

namespace PriceCalculatorKata.Common;

public static class FloatExtensions
{
    public static bool IsPositive(this float source)
    {
        if (source <= 0) return false;
        return true;
    }

    public static string SetPrecision(this float source, int precision)
    {
        NumberFormatInfo setPrecision = new NumberFormatInfo
        {
            NumberDecimalDigits = 2
        };
        return source.ToString("N", setPrecision);
    }
}