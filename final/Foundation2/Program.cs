using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private int productId;
    private float price;
    private int quantity;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public float Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public float TotalCost()
    {
        return price * quantity;
    }
}

class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string StateProvince
    {
        get { return stateProvince; }
        set { stateProvince = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public bool IsUSA()
    {
        return country.ToLower() == "usa";
    }

    public string FullAddress()
    {
        return $"{street}\n{city}, {stateProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public bool IsUSA()
    {
        return address.IsUSA();
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public List<Product> Products
    {
        get { return products; }
    }

    public Customer Customer
    {
        get { return customer; }
        set { customer = value; }
    }

    public float CalcTotalCost()
    {
        float total = 0;
        foreach (Product product in products)
        {
            total += product.TotalCost();
        }

        if (customer.IsUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address.FullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create first order
        Order order1 = new Order();
        Customer customer1 = new Customer();
        Address address1 = new Address();
        
        address1.Street = "123 Main St";
        address1.City = "Boston";
        address1.StateProvince = "MA";
        address1.Country = "USA";

        customer1.Name = "John Adams";
        customer1.Address = address1;

        Product product1 = new Product();
        product1.Name = "Herbal Tea";
        product1.ProductId = 111;
        product1.Price = 15.75f;
        product1.Quantity = 3;

        Product product2 = new Product();
        product2.Name = "Boat";
        product2.ProductId = 222;
        product2.Price = 1500.00f;
        product2.Quantity = 1;

        order1.Customer = customer1;
        order1.Products.Add(product1);
        order1.Products.Add(product2);

        // Create second order
        Order order2 = new Order();
        Customer customer2 = new Customer();
        Address address2 = new Address();

        address2.Street = "456 Elm St";
        address2.City = "Toronto";
        address2.StateProvince = "ON";
        address2.Country = "Canada";

        customer2.Name = "Thomas Jefferson";
        customer2.Address = address2;

        Product product3 = new Product();
        product3.Name = "Wig";
        product3.ProductId = 333;
        product3.Price = 45.00f;
        product3.Quantity = 2;

        Product product4 = new Product();
        product4.Name = "Pen & Ink";
        product4.ProductId = 444;
        product4.Price = 20.00f;
        product4.Quantity = 5;

        order2.Customer = customer2;
        order2.Products.Add(product3);
        order2.Products.Add(product4);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalcTotalCost():0.00}\n");
    }
}