namespace PayRoll.Models;
/// <summary>
/// Child class of Employee having fixed Type = "Contract"
/// have a overriding method "CalculatePay() to calculate net salary
/// </summary>
public class ContractEmployee : Employee
{
    public decimal DailyRate { get; set;}
    public int WorkingDays { get; set;}

    /// <summary>
    /// public constructor to assign values to ContractEmployee class's properties
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="dailyrate"></param>
    /// <param name="workingdays"></param>
    /// <exception cref="Exception"></exception>
    public ContractEmployee(int id, string name, decimal dailyrate, int workingdays) : base(id, name, "Contract")
    {
         if (dailyrate < 0)
        {
            throw new Exception("Daily Rate must be greater than 0");
        }
        DailyRate = dailyrate;
        WorkingDays = workingdays;
    }
    /// <summary>
    /// Method Overriding {RunTime Polymorphism} : Defining its own way of calculating Payroll
    /// </summary>
    /// <returns></returns>
     public override decimal CalculatePay()
    {
        return GetGross() - GetDeduction();
    }
    /// <summary>
    /// method overriding to calculate pay before deduction
    /// </summary>
    /// <returns></returns>
    public override decimal GetGross()
    {
        return DailyRate * WorkingDays;
    }

/// <summary>
/// Method overriding to calculate deduction 
/// </summary>
/// <returns></returns>
    public override decimal GetDeduction()
    {
        return GetGross() * 0.05m;
    }
}