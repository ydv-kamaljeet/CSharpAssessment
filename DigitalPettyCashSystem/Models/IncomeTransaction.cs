using System.Transactions;

namespace DigitalPettyCashSystem.Models;

public class IncomeTransaction : Transaction
{
    public string Source { get; }
    public IncomeTransaction(int id,DateOnly date,float amount,string description,string source) : base(id, date, amount, description)
    {
        Source = source;
    }  

    public override string GetSummary()
    {
        return $"[Income] {Date.ToShortDateString()} | Amount: ${Amount} | Description: {Description} | Source: {Source}";
    }  
}