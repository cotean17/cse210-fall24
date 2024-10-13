using System;
using System.Collections.Generic;

public class Order
{
    private int orderId;
    private Customer customer;
    private List<string> items;
    private decimal totalPrice;
    private string status;

    public Order(int orderId, Customer customer)
    {
        this.orderId = orderId;
        this.customer = customer;
        this.items = new List<string>();
        this.totalPrice = 0.0m;
        this.status = "Pending";
    }

    public void AddItem(string item, decimal price)
    {
        items.Add(item);
        totalPrice += price;
    }

    public decimal CalculateTotal()
    {
        return totalPrice;
    }

    public void UpdateStatus(string newStatus)
    {
        status = newStatus;
    }

    public int GetOrderId()
    {
        return orderId;
    }
}

public class Customer
{
    private int customerId;
    private string name;
    private string address;
    private string paymentInfo; // Ideally, this should be encrypted or handled securely

    public Customer(int customerId, string name, string address, string paymentInfo)
    {
        this.customerId = customerId;
        this.name = name;
        this.address = address;
        this.paymentInfo = paymentInfo;
    }

    public void UpdateAddress(string newAddress)
    {
        address = newAddress;
    }

    public void ProcessPayment(decimal amount)
    {
        // Logic to process payment (mocked for simplicity)
        Console.WriteLine($"Processing payment of {amount:C} for {name}.");
    }
}

public class Product
{
    private int productId;
    private string name;
    private decimal price;
    private int stockQuantity;

    public Product(int productId, string name, decimal price, int stockQuantity)
    {
        this.productId = productId;
        this.name = name;
        this.price = price;
        this.stockQuantity = stockQuantity;
    }

    public void UpdateStock(int quantity)
    {
        stockQuantity = quantity;
    }

    public Dictionary<string, object> GetDetails()
    {
        return new Dictionary<string, object>
        {
            { "Name", name },
            { "Price", price }
        };
    }
}
