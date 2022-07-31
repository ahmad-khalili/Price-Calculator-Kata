using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class Product
{
    public Product()
    {
        Expenses = new List<Expense>();
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

    public List<Expense> Expenses;

    public Constants.Currency Currency { get; set; } = Constants.Currency.USD;
    public void AddExpense(string description, float amount, Constants.ValueType valueType)
    {
        var expenseToAdd = new Expense
        {
            Name = description,
            Cost = amount,
            ValueType = valueType
        };
        Expenses.Add(expenseToAdd);
    }

    public bool HasExpenses()
    {
        return Expenses.Any();
    }

    public void PrintExpenses()
    {
        var currency = this.GetCurrency();
        if (HasExpenses())
        {
            foreach (var expense in Expenses)
            {
                if (expense.ValueType.Equals(Constants.ValueType.Percentage))
                    Console.WriteLine($"{expense.Name}: " +
                                      $"{(expense.Cost * Price).SetPrecision(Constants.DecimalPrecision)} {currency}");
                else Console.WriteLine($"{expense.Name}: {expense.Cost.SetPrecision(Constants.DecimalPrecision)} {currency}");
            }
        }
    }
}