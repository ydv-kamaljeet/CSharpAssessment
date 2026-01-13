namespace OrderProcessing.Models;

/// <summary>
/// Represents valid order states.
/// Enum is used for type safety and clarity.
/// </summary>
public enum OrderStatus
{
    Created,
    Paid,
    Packed,
    Shipped,
    Delivered,
    Cancelled
}
