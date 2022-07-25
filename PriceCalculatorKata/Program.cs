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

        DiscountCalculator.Percentage = 15;
        DiscountCalculator.TaxPrecedence = Constants.TaxPrecedence.After;
        SpecialDiscountCalculator.AddSpecialDiscount("789", 7, Constants.TaxPrecedence.Before);
        
        PriceCalculator.DisplayPrice(book);
    }
}