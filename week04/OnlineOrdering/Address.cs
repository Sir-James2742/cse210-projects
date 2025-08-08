public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public string getStreet()
    {
        return _street;
    }
    public void setStreet(string street)
    {
        _street = street;
    }
    public string getCity()
    {
        return _city;
    }
    public void setCity(string city)
    {
        _city = city;
    }
    public string getState()
    {
        return _state;
    }
    public void setState(string state)
    {
        _state = state;
    }
    public string getCountry()
    {
        return _country;
    }
    public void setCountry(string country)
    {
        _country = country;
    }

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }
    public bool ifUsCitizen()
    {
        if (_country.ToLower() == "usa" || _country.ToLower() == "united states")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string displayAddress()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}