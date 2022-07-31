namespace PriceCalculatorKata;

public static class Constants
{
    public const int DefaultTax = 20;
    public const int DecimalPrecisionFinal = 2;
    public const int DecimalPrecisionOperations = 4;
    public enum TaxPrecedence
    {
        Before,
        After
    }

    public enum ValueType
    {
        Percentage,
        Value
    }

    public enum CombineMethod
    {
        Additive,
        Multiplicative
    }

    public enum Currency
    {
        USD,
        GBP,
        JPY
    }
}