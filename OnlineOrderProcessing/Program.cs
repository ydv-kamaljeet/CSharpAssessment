using OrderProcessing.Data;
using OrderProcessing.Models;
using OrderProcessing.Services;

class Program
{
    static void Main()
    {
        var orderService = new OrderService();

        // Attach delegate subscribers (multicast)
        orderService.OnOrderStatusChanged += NotificationService.NotifyCustomer;
        orderService.OnOrderStatusChanged += NotificationService.NotifyLogistics;

        // Create order
        var order = orderService.CreateOrder(101, 1);

        // Add items
        order.AddItem(DataRepository.GetProductById(1), 1);
        order.AddItem(DataRepository.GetProductById(2), 2);

        Console.WriteLine($"Order Total: {order.CalculateTotal()}");

        // Status changes
        orderService.ChangeOrderStatus(order, OrderStatus.Paid);
        orderService.ChangeOrderStatus(order, OrderStatus.Packed);
        orderService.ChangeOrderStatus(order, OrderStatus.Shipped);
        orderService.ChangeOrderStatus(order, OrderStatus.Delivered);

        // Print status history
        Console.WriteLine("\nOrder Status History:");
        foreach (var log in order.StatusHistory)
        {
            Console.WriteLine($"{log.OldStatus} → {log.NewStatus} at {log.ChangedOn}");
        }
    }
}
