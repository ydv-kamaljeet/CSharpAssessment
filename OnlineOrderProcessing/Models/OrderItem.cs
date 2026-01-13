namespace OrderProcessing.Models;

/// <summary>
/// Represents a single product entry inside an order.
/// Demonstrates composition (Order HAS OrderItems).
/// </summary>
public class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }

    public decimal TotalPrice => Product.Price * Quantity;

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}
