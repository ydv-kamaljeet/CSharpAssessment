using PayRoll.Models;

namespace PayRoll.Data;

/// <summary>
/// Central Repo for Employees 
/// </summary>
public class EmployeeRepository
{
    private static List<Employee> _employees = new();

    public EmployeeRepository()
    {
        // Hardcoded data (can be replaced later)
        _employees.Add(new FullTimeEmployee(1, "Amit", 50000, 0.10m));
        _employees.Add(new ContractEmployee(2, "Ravi", 1200, 22));
        _employees.Add(new FullTimeEmployee(3, "Neha", 60000, 0.12m));
        _employees.Add(new ContractEmployee(4, "Suresh", 1000, 20));
        _employees.Add(new FullTimeEmployee(5, "Priya", 55000, 0.11m));
        _employees.Add(new ContractEmployee(6, "Anil", 900, 25));
    }

    //Method to get all the employees data {in list}
    public List<Employee> GetAllEmp()
    {
        return _employees;
    }

    //Method to add new Employeess in the list using AddRange
    public void AddEmp(List<Employee> employees)
    {
        _employees.AddRange(employees);
    }
}
