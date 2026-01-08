using System.Transactions;

namespace DigitalPettyCashSystem.Models;

/// <summary>
/// Child of transaction class having an extra property - Category
/// Have a proper implementation of GetSummary() method
/// </summary>
public class ExpenseTransaction : Transaction
{
    public string Category { get; }
    
    //constructor to assign the values
    public ExpenseTransaction(int id, DateOnly date, float amount, string description, string category) : base(id, date, amount, description)
    {
        Category = category;
    }

    //Method Overriding
    public override string GetSummary()
    {
    return $"[EXPENSE] {Date.ToShortDateString()} | Amount: ${Amount} | Description: {Description} | Category: {Category}";
    }
}
