using DigitalPettyCashSystem.Models;
namespace DigitalPettyCashSystem.Helpers;

public static class Helper
{
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