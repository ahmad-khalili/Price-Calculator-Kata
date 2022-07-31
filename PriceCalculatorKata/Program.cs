namespace PriceCalculatorKata;

public static class Program
{
    public static void Main()
    {
        var bookUsd = new Product
        {
            Name = "The Little Prince",
            UniversalProductCode = "12345",
            Price = 20.25M
        };
        
        Tax.Percentage = 21;

        Discount.Percentage = 15;

        SpecialDiscountCalculator.AddSpecialDiscount("12345", 7, Constants.TaxPrecedence.After);
        
        bookUsd.AddExpense("Transport", 0.03M, Constants.ValueType.Percentage);
        
        PriceCalculator.DisplayPrice(bookUsd, Constants.CombineMethod.Multiplicative);
    }
}
