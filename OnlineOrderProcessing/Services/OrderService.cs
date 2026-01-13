using OrderProcessing.Data;
using OrderProcessing.Models;

namespace OrderProcessing.Services;

/// <summary>
/// Handles order-related business workflows.
/// </summary>
public class OrderService
{
    // Delegate definition
    public Action<Order, OrderStatus> OnOrderStatusChanged; //Action<T> is in-built Delegate {No return value}

    //Method to create orders
    public Order CreateOrder(int orderId, int customerId)
    {
        var customer = DataRepository.GetCustomerById(customerId);
        var order = new Order(orderId, customer);

        DataRepository.AddOrder(order);
        return order;
    }

    //Method to change order status : will use callback method to store the logs as well
    public void ChangeOrderStatus(Order order, OrderStatus newStatus)
    {
        order.ChangeStatus(newStatus);

        // Notify subscribers
        OnOrderStatusChanged?.Invoke(order, newStatus);
    }
}
