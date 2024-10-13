using System;
using System.Collections.Generic;

public class Product
{
    private int productId;
    private string name;
    private decimal price;
    private int quantity;

    public Product(int productId, string name, decimal price, int quantity)
    {
        this.productId = productId;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost()
    {
        return price * quantity;
    }

    public int ProductId => productId;
    public string Name => name;
}

public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{streetAddress}\n{city}, {state}\n{country}";
    }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string Name => name;
    public Address Address => address;
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal shippingCost = customer.LivesInUSA() ? 5.00m : 35.00m;
        decimal totalProductCost = 0.0m;

        foreach (var product in products)
        {
            totalProductCost += product.TotalCost();
        }

        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        var packingLabel = "Packing Labe:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address objects
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Create customer objects
        Customer customer1 = new Customer("Jane Doe", address1);
        Customer customer2 = new Customer("John Smith", address2);

        // Create order objects
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        // Create product objects
        Product product1 = new Product(1, "Laptop", 999.99m, 1);
        Product product2 = new Product(2, "Mouse", 25.50m, 2);
        Product product3 = new Product(3, "Keyboard", 49.99m, 1);
        Product product4 = new Product(4, "Monitor", 199.99m, 1);

        // Add products to orders
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.CalculateTotalCost():C}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.CalculateTotalCost():C}");
    }
}

