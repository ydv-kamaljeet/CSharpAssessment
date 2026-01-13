namespace OrderProcessing.Models;

/// <summary>
/// Core domain entity.
/// Owns business rules related to order lifecycle.
/// </summary>
public class Order
{
    public int Id { get; }
    public Customer Customer { get; }

    private List<OrderItem> _items = new();
    private List<OrderStatusLog> _statusHistory = new();

    public List<OrderItem> Items => _items;
    public List<OrderStatusLog> StatusHistory => _statusHistory;

    public OrderStatus CurrentStatus { get; private set; }

    public Order(int id, Customer customer)
    {
        Id = id;
        Customer = customer;
        CurrentStatus = OrderStatus.Created;
    }

    public void AddItem(Product product, int quantity)
    {
        _items.Add(new OrderItem(product, quantity));
    }

    public decimal CalculateTotal()
        => _items.Sum(i => i.TotalPrice);

    /// <summary>
    /// Changes order status with validation rules.
    /// </summary>
    public void ChangeStatus(OrderStatus newStatus)
    {
        // Business rules
        if (CurrentStatus == OrderStatus.Cancelled)
            throw new InvalidOperationException("Cancelled order cannot change status.");

        if (newStatus == OrderStatus.Shipped && CurrentStatus != OrderStatus.Packed)
            throw new InvalidOperationException("Order must be packed before shipping.");

        if (newStatus == OrderStatus.Delivered && CurrentStatus != OrderStatus.Shipped)
            throw new InvalidOperationException("Order must be shipped before delivery.");

        var log = new OrderStatusLog(CurrentStatus, newStatus);
        _statusHistory.Add(log);

        CurrentStatus = newStatus;
    }
}
