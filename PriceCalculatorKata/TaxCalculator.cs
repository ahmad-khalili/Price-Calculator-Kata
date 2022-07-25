namespace PriceCalculatorKata;

public static class TaxCalculator
{
    public static float CalculateTax(float price)
    {
        var tax = Tax.Percentage / 100F;
        var taxAmount = price * tax;
        var priceAfterTax = price + taxAmount;
        return priceAfterTax;
    }
}