using DigitalPettyCashSystem.Models;
namespace DigitalPettyCashSystem.Helpers;

/// <summary>
/// It is a static Helper class to separate the calculation logic to maintain one entity one responsiblity.
/// Its methods can be called directly without creating its object.
/// </summary>
public static class Helper
{
    /// <summary>
    /// static method to calculate the total amount, its associated with class not its object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="transactions"></param>
    /// <returns></returns>
    public static float CalculateTotalAmount<T>(List<T> transactions) where T : Transaction 
    {
        float total = 0;

        foreach (T transaction in transactions)
        {
            total += transaction.Amount;
        }
        return total;
    }
}