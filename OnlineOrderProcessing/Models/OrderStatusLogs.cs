namespace OrderProcessing.Models;

/// <summary>
/// Stores history of order status changes.
/// </summary>
public class OrderStatusLog
{
    public OrderStatus OldStatus { get; }
    public OrderStatus NewStatus { get; }
    public DateTime ChangedOn { get; }

    public OrderStatusLog(OrderStatus oldStatus, OrderStatus newStatus)
    {
        OldStatus = oldStatus;
        NewStatus = newStatus;
        ChangedOn = DateTime.Now;
    }
}
