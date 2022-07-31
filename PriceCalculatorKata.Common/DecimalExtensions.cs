using System.Globalization;
using Microsoft.VisualBasic;

namespace PriceCalculatorKata.Common;

public static class DecimalExtensions
{
    public static bool IsValid(this decimal source)
    {
        if (source <= 0) return false;
        return true;
    }

    public static decimal SetPrecision(this decimal source, int decimalPrecision)
    {
        var newDecimal = Decimal.Round(source, decimalPrecision);
        return newDecimal;
    }
}