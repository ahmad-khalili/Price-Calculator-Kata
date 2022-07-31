using PriceCalculatorKata.Common;

namespace PriceCalculatorKata;

public class Product
{
    public Product()
    {
        Expenses = new List<Expense>();
    }
    
    private string? _name;
    public string? Name
    {
        get => _name;
        
        set
        {
            if (!value.IsValid())
                throw new ArgumentException("Invalid Product Name!", $"{value}");
            _name = value;
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

    private decimal _price;
    public decimal Price
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
    public void AddExpense(string description, decimal amount, Constants.ValueType valueType)
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