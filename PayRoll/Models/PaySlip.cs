namespace PayRoll.Models;

/// <summary>
/// Class having properties of Employee and their salary details 
/// </summary>
public class PaySlip
{
    public int Id { get; }
    public string? Name { get; }
    public string? Type { get; }
    public decimal Gross { get; }   //Total Pay before deduction
    public decimal Deduction { get; }   //tax
    public decimal Net { get; }     //Total Pay after deduction

    /// <summary>
    /// public constructor to assign values in PaySlip properties
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <param name="gross"></param>
    /// <param name="deduction"></param>
    /// <param name="net"></param>
    public PaySlip(int id, string name, string type, decimal gross, decimal deduction, decimal net)
    {
        Id = id;
        Name = name;
        Type = type;
        Gross = gross;
        Deduction = deduction;
        Net = net;
    }
}
