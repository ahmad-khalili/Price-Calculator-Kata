using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class Product
{
    private int _productId;
    public int ProductId
    {
        get => _productId;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Product ID", $"{value}");
            _productId = value;
        }
    }

    private string? _productName;
    public string? ProductName
    {
        get => _productName;
        
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Product Name!", $"{value}");
            _productName = value;
        }
    }

    private string? _universalProductCode;
    public string? UniversalProductCode
    {
        get => _universalProductCode;
        set
        {
            if(!value.IsValid())
                throw new ArgumentException("Invalid Product Code!", $"{value}");
            _universalProductCode = value;
        }
    }

    private float _price;
    public float Price
    {
        get => _price;

        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Specified Price!", $"{value}");
            _price = value;
        }
    }
}