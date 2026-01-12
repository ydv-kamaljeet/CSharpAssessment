using PayRoll.Models;

namespace PayRoll.Services;

public class PayrollEngine
{
    private static  List<Employee> _employees; //Generic to store Employees data
    private static  List<PaySlip> _paySlips = new();   //Generic to store the Pay slips 

    // Delegate
    public Action<PaySlip>? SalaryProcessed;

    //constructor to populate the employess list
    public PayrollEngine(List<Employee> employees)
    {
        _employees = employees;
    }

    // central brain of this probleme.
    public void ProcessPayroll()
    {
        foreach (Employee emp in _employees)
        {
            decimal net = emp.CalculatePay();   // polymorphism implementation

            //Creating payslip
            PaySlip slip = new PaySlip(emp.Id, emp.Name, emp.Type, emp.GetGross(), emp.GetDeduction(), net);
            //Adding payslip in list
            _paySlips.Add(slip);
            //Executing the delegate methods
            SalaryProcessed?.Invoke(slip); // multicast delegate
        }
    }

    public List<PaySlip> GetPaySlips() => _paySlips;    //delegate method
}
