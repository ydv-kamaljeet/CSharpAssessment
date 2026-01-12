namespace PayRoll.Models;
/// <summary>
/// Base Abstract class having base porperties like , id, name , type and some abstract methods that will be overriden in child classes.
/// </summary>
public abstract class Employee
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public string? Type{get;set;}
    //created protected constructor to restrict the object creation directly in different class. Now we can call this constructor
    //  only in child classes.
    protected Employee(int id, string name, string employeeType)
    {
        Id = id;
        Name = name;
        Type = employeeType;
    }
    
    //Some abstract methods that need to be overridden in child class.
    public abstract decimal CalculatePay();
    // Polymorphic helpers (no if/else anywhere)
    public abstract decimal GetGross();
    public abstract decimal GetDeduction();
} 



