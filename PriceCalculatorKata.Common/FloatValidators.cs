﻿namespace PriceCalculatorKata.Common;

public static class FloatValidators
{
    public static bool IsValid(this float source)
    {
        if (source <= 0) return false;
        return true;
    }
}