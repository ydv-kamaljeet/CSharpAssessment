
using DigitalPettyCashSystem.Models;
using DigitalPettyCashSystem.Helpers;
using DigitalPettyCashSystem.DataBank;
using System.Globalization;
using System.Runtime.CompilerServices;
namespace DigitalPettyCashSystem.Ledger;

/// <summary>
/// Generic class : Where we are gonna create class of these 2 types - income or expense class.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Ledger<T> where T : Transaction
{
    private  List<T> _transactions = new List<T>();     // made it private so that only Transaction class object can access it. and used "_" as its a private field.
    public void AddEntry(T entry)
    {
        _transactions.Add(entry);
    }

/// <summary>
/// Member function to get the transactions of a specific Date. Eg. - transaction of 1 January,2026.
/// </summary>
/// <param name="date"></param>
/// <returns></returns>
    public List<T> GetTransactionsByDate(DateOnly date) //For filter out transaction of specific Date
    {
        List<T> result = new List<T>();
        foreach (T transaction in _transactions)
        {
            if (transaction.Date == date)   //checking whether this transaction is on the given date or not. If yes, add it in result.
            {
                result.Add(transaction);    //Adding into separate list
            }
        }
        return result;  //returing the filtered out transactions
    }

    public float CalculateTotal(){
        return Helper.CalculateTotalAmount<T>(_transactions);  //calling from static class {i.e. separate calculation class}
    }

    public List<T> GetAll()
    {
        return _transactions;
    }
}