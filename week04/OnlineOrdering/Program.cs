using System;

class Program
{
    static void Main(string[] args)
    {
        // Example usage of the classes
        Address address1 = new Address("123 Main St", "Springfield", "ILinois", "USA");
        Customer customer1 = new Customer("Jenipher Wright", address1);

        Product product1 = new Product("Headlight", 999.99, 1, "P001");
        Product product2 = new Product("Windshield", 2500.50, 2, "P002");
        Product product3 = new Product("Tires", 450.00, 1, "P003");

        List<Product> products = new List<Product> { product1, product2, product3 };
        Order order = new Order(customer1, products);

        Console.WriteLine(order.shippingLabel());
        Console.WriteLine($"Total Price: {order.totalPrice}");
        order.parkingLabel();

        Address address2 = new Address("Express way", "Nairobi", "Nairobi", "Kenya");
        Customer customer2 = new Customer("Joseph liech", address2);

        Product spare1 = new Product("Chairs", 459, 5, "P0011");
        Product spare2 = new Product("Sunroof", 200.50, 2, "P0021");
        Product spare3 = new Product("Suspensions", 450.00, 6, "P0031");

        List<Product> products1 = new List<Product> { spare1, spare2, spare3 };
        Order order1 = new Order(customer2, products1);

        Console.WriteLine(order1.shippingLabel());
        Console.WriteLine($"Total Price: {order1.totalPrice}");
        order1.parkingLabel();
    }
}