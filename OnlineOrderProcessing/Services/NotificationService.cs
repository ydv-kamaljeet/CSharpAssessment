using OrderProcessing.Models;

namespace OrderProcessing.Services;

/// <summary>
/// Contains notification handlers.
/// Demonstrates delegates & multicast.
/// </summary>
public static class NotificationService
{
    //Delegate method 1
    public static void NotifyCustomer(Order order, OrderStatus newStatus)
    {
        Console.WriteLine(
            $"[Customer Notification] Order {order.Id} is now {newStatus}");
    }
    //Delegate Method 2
    public static void NotifyLogistics(Order order, OrderStatus newStatus)
    {
        Console.WriteLine(
            $"[Logistics Notification] Prepare order {order.Id} for {newStatus}");
    }
}
