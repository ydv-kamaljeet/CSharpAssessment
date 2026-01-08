using System.Transactions;

namespace DigitalPettyCashSystem.Models;

/// <summary>
/// Child of Transaction class having an extra property Source
/// Have proper implementation of GetSummary() method according to this class only.
/// </summary>
public class IncomeTransaction : Transaction
{
    public string Source { get; }

    #region constructor
    /// <summary>
    /// Constructor: to assign the values while creating object
    /// </summary>
    /// <param name="id"></param>
    /// <param name="date"></param>
    /// <param name="amount"></param>
    /// <param name="description"></param>
    /// <param name="source"></param>
    public IncomeTransaction(int id,DateOnly date,float amount,string description,string source) : base(id, date, amount, description)
    {
        Source = source;
    }  
    #endregion
    
    //Method Overriding
    public override string GetSummary()
    {
        return $"[Income] {Date.ToShortDateString()} | Amount: ${Amount} | Description: {Description} | Source: {Source}";
    }  
}