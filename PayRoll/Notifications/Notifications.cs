using PayRoll.Models;

namespace PayRoll.Notifications;

/// <summary>
/// Helper class having Delegate methods 
/// </summary>
public static class NotificationHandlers
{
    //Delegate method 1
    public static void NotifyHR(PaySlip slip)
    {
        Console.WriteLine($"[HR] Salary processed for {slip.Name} ({slip.Type})");
    }
    //Delegate method 2
    public static void NotifyFinance(PaySlip slip)
    {
        Console.WriteLine($"[Finance] Net salary to be paid: {slip.Net}");
    }
}
