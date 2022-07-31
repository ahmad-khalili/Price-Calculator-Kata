using System.Globalization;

namespace PriceCalculatorKata.Common;

public static class DecimalExtensions
{
    public static bool IsValid(this decimal source)
    {
        if (source <= 0) return false;
        return true;
    }

    public static string SetPrecision(this decimal source, int precision)
    {
        NumberFormatInfo setPrecision = new NumberFormatInfo
        {
            NumberDecimalDigits = 2
        };
        return source.ToString("N", setPrecision);
    }
}