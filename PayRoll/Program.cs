using PayRoll.Models;
using PayRoll.Services;
using PayRoll.Notifications;
using PayRoll.Data;
using System.Security.Cryptography.X509Certificates;
namespace  PayRoll;
/// <summary>
/// Main Entry point of this project
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        //creating list of Employees : Act as DataBank {HardCoded}
        EmployeeRepository emprepo = new EmployeeRepository();

        //want to test on these employees as well including the pre-existing data
        List<Employee> employees = new()
        {
            new FullTimeEmployee(7, "Igloo", 50000, 0.10m),
            new ContractEmployee(8, "Kamaljeet", 900, 25)
        };
        emprepo.AddEmp(employees);  //Adding the new list of employees.

        //creating the object of PayRollEngine class
        PayrollEngine engine = new PayrollEngine(emprepo.GetAllEmp());

        // Multicast delegate
        engine.SalaryProcessed += NotificationHandlers.NotifyHR;
        engine.SalaryProcessed += NotificationHandlers.NotifyFinance;

        engine.ProcessPayroll();

        Console.WriteLine("\n--- Payroll Summary ---");
        //calculating the totalPayout and printing the payslips of employees
        decimal totalPayout = 0;
        foreach (var slip in engine.GetPaySlips())
        {
            Console.WriteLine( $"{slip.Id} | {slip.Name} | {slip.Type} | " + $"Gross: {slip.Gross} | Deduction: {slip.Deduction} | Net: {slip.Net}");
            totalPayout += slip.Net;    //Adding the totalPayout 
        }

        Console.WriteLine($"\nTotal Employees: {engine.GetPaySlips().Count}");
        Console.WriteLine($"Total Payout: {totalPayout}");
    }

}