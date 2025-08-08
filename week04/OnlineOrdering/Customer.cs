public class Customer
{
    private string _name;
    public Address _address { get; set; }

    public string getName()
    {
        return _name;
    }
    public void setName(string name)
    {
        _name = name;
    }
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public bool UscitizenStatus()
    {
        return _address.ifUsCitizen();
    }
    public string displayCustomerInfo()
    {
        return $"Customer Name: {_name}, Address: {_address.displayAddress()}";
    }
}