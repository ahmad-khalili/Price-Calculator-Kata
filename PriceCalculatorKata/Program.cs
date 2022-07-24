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
        DiscountCalculator.DiscountPercentage = 15;
        DiscountCalculator.AddSpecialDiscount(book.UniversalProductCode, 7);
        
        PriceCalculator.DisplayPrice(book);
        
        Console.WriteLine();

        var newBook = new Product
        {
            ProductName = "The Big Prince",
            UniversalProductCode = "11587",
            Price = 20.25F
        };
        
        TaxCalculator.TaxPercentage = 21;
        DiscountCalculator.AddSpecialDiscount("789", 7);
        PriceCalculator.DisplayPrice(newBook);
    }
}