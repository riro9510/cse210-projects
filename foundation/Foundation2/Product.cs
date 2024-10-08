class Product
{
    private string _Name;
    private string _ProductId;
    private decimal _Price;
    private int _Quantity;

    public Product(string Name, string ProductId, decimal Price, int Quantity)
    {
        _Name = Name;
        _ProductId = ProductId;
        _Price = Price;
        _Quantity = Quantity;
    }

    public decimal TotalCost()
    {
        return _Price * _Quantity;
    }

    public string GetName()
    {
        return _Name;
    }

    public string GetProductId()
    {
        return _ProductId;
    }
}