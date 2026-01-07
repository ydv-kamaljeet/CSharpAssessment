namespace DigitalPettyCashSystem.Models;
using DigitalPettyCashSystem.Interfaces;

public abstract class Transaction : IReportable
{
    public int Id{get;}
    public DateOnly Date{get;}
    public float Amount{get;}
    public string? Description{get;}

    
    protected Transaction(int id, DateOnly date, float amount, string description)
    {
        Id = id;
        Date = date;
        Amount = amount;
        Description = description;
    }
        public abstract string GetSummary();
}

