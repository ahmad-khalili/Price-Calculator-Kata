namespace PriceCalculatorKata;

public static class Currency
{
    public static string GetCurrency(this Product product)
    {
        if (product.Currency.Equals(Constants.Currency.USD)) return "USD";
        
        if (product.Currency.Equals(Constants.Currency.GBP)) return "GBP";
        
        if (product.Currency.Equals(Constants.Currency.JPY)) return "JPY";

        return "NA";
    }
}