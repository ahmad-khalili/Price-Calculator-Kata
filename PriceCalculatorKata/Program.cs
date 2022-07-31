namespace PriceCalculatorKata;

public static class Program
{
    public static void Main()
    {
        var bookUsd = new Product
        {
            Name = "The Little Prince",
            UniversalProductCode = "12345",
            Price = 20.25F
        };
        
        TaxCalculator.Percentage = 20;
        
        PriceCalculator.DisplayPrice(bookUsd, Constants.CombineMethod.Additive);
        
        Console.WriteLine();

        var bookGbp = new Product
        {
            Name = "The Little Prince",
            UniversalProductCode = "12345",
            Price = 17.76F,
            Currency = Constants.Currency.GBP
        };
        
        PriceCalculator.DisplayPrice(bookGbp, Constants.CombineMethod.Additive);
    }
}
