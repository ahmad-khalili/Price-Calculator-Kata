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
        
        TaxCalculator.Percentage = 21;
        
        DiscountCalculator.Percentage = 15;
        DiscountCalculator.TaxPrecedence = Constants.TaxPrecedence.After;
        SpecialDiscountCalculator.AddSpecialDiscount("12345", 7, Constants.TaxPrecedence.After);
        
        
        PriceCalculator.SetCap(0.20F, Constants.ValueType.Percentage);
        PriceCalculator.DisplayPrice(book, Constants.CombineMethod.Additive);
        
        Console.WriteLine();
        
        PriceCalculator.SetCap(4, Constants.ValueType.Value);
        PriceCalculator.DisplayPrice(book, Constants.CombineMethod.Additive);
        
        Console.WriteLine();
        
        PriceCalculator.SetCap(0.30F, Constants.ValueType.Percentage);
        PriceCalculator.DisplayPrice(book, Constants.CombineMethod.Additive);
    }
}
