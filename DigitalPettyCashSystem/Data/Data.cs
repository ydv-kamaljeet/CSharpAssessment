using DigitalPettyCashSystem.Helpers;
using DigitalPettyCashSystem.Models;
using DigitalPettyCashSystem.Ledger;

namespace DigitalPettyCashSystem.DataBank;

public class Data
{
    public void Execute()
    {
        var incomeLedger = new Ledger<IncomeTransaction>();
        var expenseLedger = new Ledger<ExpenseTransaction>();

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);//Todays Date

        incomeLedger.AddEntry(new IncomeTransaction(1, today, 500,"Fund replenishment","Main Cash"));

        expenseLedger.AddEntry(new ExpenseTransaction(1, today, 20,"Stationery purchase","Office"));

        expenseLedger.AddEntry(new ExpenseTransaction(2, today, 15,"Team snacks","Food"));
            
        float totalIncome = incomeLedger.CalculateTotal();
        float totalExpense = expenseLedger.CalculateTotal();
        float netBalance = totalIncome - totalExpense;

        // Output
        Console.WriteLine($"Total Income   : {totalIncome}");
        Console.WriteLine($"Total Expense  : {totalExpense}");
        Console.WriteLine($"Net Balance    : {netBalance}");

        Console.WriteLine("\n--- Transaction Summary ---");

        foreach (var tx in incomeLedger.GetAll())
            Console.WriteLine(tx.GetSummary());

        foreach (var tx in expenseLedger.GetAll())
            Console.WriteLine(tx.GetSummary());
       
    }
 }
