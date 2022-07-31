namespace PriceCalculatorKata;

public static class ExpenseCalculator
{
    public static decimal CalculateExpenses(Product product)
    {
        if (!product.HasExpenses()) return 0;
        decimal totalExpenses = 0;
        foreach (var expense in product.Expenses)
        {
            if (expense.ValueType.Equals(Constants.ValueType.Value))
                totalExpenses += expense.Cost;
            else
            {
                var expenseAmount = expense.Cost * product.Price;
                totalExpenses += expenseAmount;
            }
        }

        return totalExpenses;
    }
}