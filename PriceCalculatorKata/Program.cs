namespace PriceCalculatorKata;

public static class Program
{
    public static void Main()
    {
        var priceCalculator = new PriceCalculator();
        
        var book = new Product
        {
            ProductName = "The Little Prince",
            UniversalProductCode = "12345",
            Price = 20.25F
        };
        Discount.Percentage = 15;
        Discount.TaxPrecedence = Constants.TaxPrecedence.After;
        SpecialDiscountCalculator.AddSpecialDiscount(book.UniversalProductCode, 7, Constants.TaxPrecedence.Before);
        
        priceCalculator.DisplayPrice(book);
    }
}