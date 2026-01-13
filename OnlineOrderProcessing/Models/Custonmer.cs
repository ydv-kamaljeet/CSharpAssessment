namespace OrderProcessing.Models;

/// <summary>
/// Represents a customer placing orders.
/// </summary>
public class Customer
{
    public int Id { get; }
    public string Name { get; }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
