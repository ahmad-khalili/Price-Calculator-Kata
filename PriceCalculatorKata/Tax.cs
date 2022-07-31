using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public static class Tax
{
    private static int _tax = Constants.DefaultTax;
    public static int Percentage
    {
        get => _tax;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Tax Percentage", $"{value}");
            _tax = value;
        }
    }
    public static decimal CalculateTaxAmount(decimal price)
    {
        var tax = Percentage / 100M;
        var taxAmount = price * tax;
        return taxAmount.SetPrecision(Constants.DecimalPrecisionOperations);
    }

    public static void PrintTaxAmount(Product product)
    {
        if (Percentage > 0)
        {
            var taxAmount = CalculateTaxAmount(product.Price);
            var currency = product.GetCurrency();
            Console.WriteLine($"Total Tax Amount: {taxAmount.SetPrecision(Constants.DecimalPrecisionFinal)} {currency}");
        }
    }
}