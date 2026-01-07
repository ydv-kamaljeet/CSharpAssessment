using System.Transactions;

namespace DigitalPettyCashSystem.Models;

public class ExpenseTransaction : Transaction
{
    public string Category { get; }
    public ExpenseTransaction(int id, DateOnly date, float amount, string description, string category) : base(id, date, amount, description)
    {
        Category = category;
    }
    public override string GetSummary()
    {
    return $"[EXPENSE] {Date.ToShortDateString()} | Amount: ${Amount} | Description: {Description} | Category: {Category}";
    }
}
