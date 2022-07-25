using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class SpecialDiscount
{
    private int _discountPercentage;
    public int DiscountPercentage
    {
        get => _discountPercentage;

        set
        {
            if (!_discountPercentage.IsValid())
                throw new ArgumentException("Special Discount should be higher than 0%");

            _discountPercentage = value;
        }
    }

    public Constants.TaxPrecedence TaxPrecedence { get; set; }

    private string? _discountedProductCode;

    public string? DiscountedProductCode
    {
        get => _discountedProductCode;
        set
        {
            if (!_discountedProductCode.IsValid())
                throw new ArgumentException("Invalid Product Code! (Special Discount)", $"{_discountedProductCode}");
            
            _discountedProductCode = value;
        }
    }

    public bool IsBeforeTax()
    {
        var isBefore = TaxPrecedence.Equals(Constants.TaxPrecedence.Before);
        if (isBefore) return true;
        return false;
    }
}