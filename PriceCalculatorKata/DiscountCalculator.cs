namespace PriceCalculatorKata;

public static class DiscountCalculator
{
    private static float CalculateDiscountAmount(float price)
    {
        var discount = Discount.Percentage / 100F;
        var discountAmount = price * discount;
        return discountAmount;
    }

    public static float CalculateDiscount(float price)
    {
        var discountAmount = CalculateDiscountAmount(price);
        price -= discountAmount;
        return price;
    }
}