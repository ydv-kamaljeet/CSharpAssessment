using OrderProcessing.Models;

namespace OrderProcessing.Data;

/// <summary>
/// Central in-memory data store.
/// Acts like a fake database.
/// </summary>
public static class DataRepository
{
    //Central Data Repository to store the data of Products, Customers , Orders
    private static Dictionary<int, Product> _products = new();
    private static Dictionary<int, Customer> _customers = new();
    private static List<Order> _orders = new();

    // Static constructor loads master data once
    static DataRepository()
    {
        LoadProducts();
        LoadCustomers();
    }

    //Adding the hard coded data of Products
    private static void LoadProducts()
    {
        _products.Add(1, new Product(1, "Laptop", 55000));
        _products.Add(2, new Product(2, "Mouse", 500));
        _products.Add(3, new Product(3, "Keyboard", 1200));
        _products.Add(4, new Product(4, "Monitor", 15000));
        _products.Add(5, new Product(5, "Headset", 2500));
    }
    //Adding the hard coded data of Customers
    private static void LoadCustomers()
    {
        _customers.Add(1, new Customer(1, "Amit"));
        _customers.Add(2, new Customer(2, "Neha"));
        _customers.Add(3, new Customer(3, "Rahul"));
    }

    //Getter for Products
    public static Product GetProductById(int id)
        => _products[id];

    //Getter for Customers
    public static Customer GetCustomerById(int id)
        => _customers[id];

    //to Add new Orders in list
    public static void AddOrder(Order order)
        => _orders.Add(order);

    //Fetching all the orders
    public static List<Order> GetAllOrders()
        => _orders;
}
