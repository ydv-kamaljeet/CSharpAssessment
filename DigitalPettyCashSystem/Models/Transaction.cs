namespace DigitalPettyCashSystem.Models;
using DigitalPettyCashSystem.Interfaces;

/// <summary>
/// Its a Base class having some properties 
/// It's a abstract class because we dont need to create object of this class directly.
/// </summary>
public abstract class Transaction : IReportable //Interface implemented
{
    public int Id{get;}
    public DateOnly Date{get;}
    public float Amount{get;}
    public string? Description{get;}

    /// <summary>
    /// Its a Protected constructor.Why ?
    /// > Cannot be called from outside the class hierarchy
    /// > Can be called by derived classes
    /// > Cannot be instantiated directly
    /// </summary>
    /// <param name="id"></param>
    /// <param name="date"></param>
    /// <param name="amount"></param>
    /// <param name="description"></param>
    protected Transaction(int id, DateOnly date, float amount, string description)
    {
        Id = id;
        Date = date;
        Amount = amount;
        Description = description;
    }
        public abstract string GetSummary();    //Making it abstract to define in child class with their own defination.
}

