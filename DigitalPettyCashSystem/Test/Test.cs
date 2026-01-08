using DigitalPettyCashSystem.Helpers;
using DigitalPettyCashSystem.Models;
using DigitalPettyCashSystem.Ledger;

namespace DigitalPettyCashSystem.Testing;
/// <summary>
/// This class is created to test the functionality like adding transactions , listing all or get transaction by Date 
/// instead of writing whole code in main function , we created separate class.
/// </summary>
public class Test
{
    public void Execute()
    {
        
        var incomeLedger = new Ledger<IncomeTransaction>(); //To store Income transactions
        var expenseLedger = new Ledger<ExpenseTransaction>();   //To store Expense Transactions

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);//Todays Date
        string dateInput = "2021/10/22";
        // (throws an exception if parsing fails)
        DateOnly date = DateOnly.Parse(dateInput);

        #region Data Feeding
        //Creating objects and adding the transactions
        incomeLedger.AddEntry(new IncomeTransaction(1, today, 500, "Fund replenishment", "Main Cash"));
        incomeLedger.AddEntry(new IncomeTransaction(1, date, 500, " Seed Funding ", "Cash"));
        expenseLedger.AddEntry(new ExpenseTransaction(1, date, 20, "Stationery purchase", "Office"));
        expenseLedger.AddEntry(new ExpenseTransaction(2, today, 15, "Team snacks", "Food"));
        expenseLedger.AddEntry(new ExpenseTransaction(2, date, 15, "Team Dinner", "Food"));
        expenseLedger.AddEntry(new ExpenseTransaction(2, today, 15, "Resources bill", "AWS Bill"));
        #endregion

        #region Calculations

        //Calculatinfg these values as required
        float totalIncome = incomeLedger.CalculateTotal();
        float totalExpense = expenseLedger.CalculateTotal();
        float netBalance = totalIncome - totalExpense;
        
        #endregion


        #region // Output
        Console.WriteLine($"Total Income   : {totalIncome}");
        Console.WriteLine($"Total Expense  : {totalExpense}");
        Console.WriteLine($"Net Balance    : {netBalance}");

        Console.WriteLine("\n--- Transaction Summary ---");
        foreach (var tx in incomeLedger.GetAll())
            Console.WriteLine(tx.GetSummary());
        foreach (var tx in expenseLedger.GetAll())
            Console.WriteLine(tx.GetSummary());
        #endregion

        #region Print Expense Transaction by this date
        Console.WriteLine("\n--- Expenses on 2021/10/22 ---");
        List<ExpenseTransaction> expensesOnDate = expenseLedger.GetTransactionsByDate(date);    //filter the expense transactions
        
        //Printing the summary
        foreach (var tx in expensesOnDate)
        {
            Console.WriteLine(tx.GetSummary());
        }
        #endregion

        #region Print Income Transaction by Date

        //TO get all the Income transaction on this date
        Console.WriteLine("\n--- Income on 2021/10/22 ---");
        List<IncomeTransaction> incomeOnDate = incomeLedger.GetTransactionsByDate(date);   //filtered out the trasactions

        //print summary of each transaction
        foreach (var tx in incomeOnDate)
        {
            Console.WriteLine(tx.GetSummary());
        }
        #endregion

    }
}
