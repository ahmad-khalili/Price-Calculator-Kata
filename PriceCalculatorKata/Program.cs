namespace PriceCalculatorKata;

public static class Program
{
    public static void Main()
    {
        var book = new Product
        {
            ProductName = "The Little Prince",
            UniversalProductCode = "12345",
            Price = 20.25F
        };
        PriceCalculator.DisplayPrice(book);
        PriceCalculator.DiscountPercentage = 15;
        Console.WriteLine();
        PriceCalculator.DisplayPrice(book);
    }
}