public class Product
{
    private string _name;
    private double _price;
    private int _quantity;
    private string _productId;

    public string getName()
    {
        return _name;
    }
    
    public void setName(string name)
    {
        _name = name;
    }
    
    public double getPrice()
    {
        return _price;
    }
    
    public void setPrice(double price)
    {
        _price = price;
    }
    
    public int getQuantity()
    {
        return _quantity;
    }
    
    public void setQuantity(int quantity)
    {
        _quantity = quantity;
    }
    public string getProductId()
    {
        return _productId;
    }
    public void setProductId(string productId)
    {
        _productId = productId;
    }

    public Product(string name, double price, int quantity, string productId)
    {
        _productId = productId;
        _name = name;
        _price = price;
        _quantity = quantity;
        _productId = productId;
    }
   
    public double calculateTotalPrice()
    {
        return _price * _quantity;
    }
}