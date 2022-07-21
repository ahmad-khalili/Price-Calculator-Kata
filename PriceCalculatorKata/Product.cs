using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class Product
{
    public int ProductId { get; set; }
    private string? _productName;

    public string? ProductName
    {
        get => _productName;
        
        set
        {
            if (!value.StringValid())
                throw new ArgumentNullException(value ,"Invalid Product Name!");
            _productName = value;
        }
    }

    private string? _universalProductCode;

    public string? UniversalProductCode
    {
        get => _universalProductCode;
        set
        {
            if(!value.StringValid())
                throw new ArgumentNullException(value ,"Invalid Product Code!");
            _universalProductCode = value;
        }
    }

    private float _price;
    public float Price
    {
        get => _price;

        set
        {
            if (!value.FloatValid())
                throw new ArgumentException("Invalid Specified Price!", $"{value}");
            _price = value;
        }
    }
}