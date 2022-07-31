﻿namespace PriceCalculatorKata;

public static class Constants
{
    public const int DefaultTax = 20;
    public const int DecimalPrecision = 2;
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