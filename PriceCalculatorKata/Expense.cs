using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public struct Expense
{
    private string? _name;

    public string? Name
    {
        get => _name;
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Expense Name cannot be empty!", $"{value}");
            _name = value;
        }
    }

    private decimal _cost;

    public decimal Cost
    {
        get => _cost;
        set
        {
            if(!value.IsValid())
                throw new ArgumentException("Cost has to be bigger than 0!", $"{value}");
            _cost = value;
        }

    }
    
    public Constants.ValueType ValueType { get; set; }
}