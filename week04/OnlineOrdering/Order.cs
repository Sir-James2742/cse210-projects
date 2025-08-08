public class Order
{
    public Customer _customer { get; set; }
    public List<Product> _products { get; set; }

    public double totalPrice { get; set; }
    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
        totalPrice = calculateTotalPrice();
    }
    public double calculateTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.calculateTotalPrice();
        }
        return total + shippingCost();
    }

    public double shippingCost()
    {
        if (_customer.UscitizenStatus())
        {
            return 0.05 * totalPrice;
        }
        else
        {
            return 0.35 * totalPrice;
        }
    }
    public string shippingLabel()
    {
        return $"Shipping to: {_customer.displayCustomerInfo()}";
    }
    public void parkingLabel()
    {
        foreach (var product in _products)
        {
            Console.WriteLine($"Product: {product.getName()}, ID: {product.getProductId()}");
        }
    }

}