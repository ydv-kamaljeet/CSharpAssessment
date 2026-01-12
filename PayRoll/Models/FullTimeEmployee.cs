namespace PayRoll.Models;
/// <summary>
/// Child class of Employee Class having properties and method "CalculatePay()" is overriding in this class
/// </summary>
public class FullTimeEmployee : Employee
{
    public decimal MonthlySalary{get;set;}
    public decimal TaxRate{get;set;}
    /// <summary>
    /// public constructor to assign values in FulltimeEmployee class porperties
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="salary"></param>
    /// <param name="taxRate"></param>
    /// <exception cref="Exception"></exception>
    public FullTimeEmployee(int id, string name, decimal salary, decimal taxRate) : base(id, name, "FullTime")
    {
        if (salary < 0)
        {
            throw new Exception("Salary must be greater than 0");
        }
        MonthlySalary = salary;
        TaxRate = taxRate;
    }

    //Method Overriding : Own implementation of calculating the Salaray Pay
    public override decimal CalculatePay()
    {
        return MonthlySalary - GetDeduction();
    }
    public override decimal GetGross()
    {
        return MonthlySalary;
    }
    public override decimal GetDeduction()
    {
        return MonthlySalary * TaxRate;
    }

}