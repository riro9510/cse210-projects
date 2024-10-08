class Customer
{
    private string _Name;
    private Address _Address;

    public Customer(string Name, Address Adress)
    {
        _Name = Name;
        _Address = Adress;
    }

    public bool LivesInUSA()
    {
        return _Address.IsInUSA();
    }

    public string GetName()
    {
        return _Name;
    }

    public Address GetAddress()
    {
        return _Address;
    }
}