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
        
        book.AddExpense("Packaging", 0.01F, Constants.ExpenseType.Percentage);
        book.AddExpense("Transport", 2.2F, Constants.ExpenseType.Value);

        TaxCalculator.Percentage = 21;

        DiscountCalculator.Percentage = 15;
        DiscountCalculator.TaxPrecedence = Constants.TaxPrecedence.After;
        SpecialDiscountCalculator.AddSpecialDiscount("12345", 7, Constants.TaxPrecedence.After);
        
        PriceCalculator.DisplayPrice(book);
    }
}
