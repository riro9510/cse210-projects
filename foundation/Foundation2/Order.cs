class Order
{
    private Customer _Customer;
    private List<Product> _Products;

    public Order(Customer Customer)
    {
        _Customer = Customer;
        _Products = new List<Product>();
    }

    public void AddProduct(Product Product)
    {
        _Products.Add(Product);
    }

    public decimal TotalCost()
    {
        decimal total = 0;
        foreach (var product in _Products)
        {
            total += product.TotalCost();
        }

        decimal shippingCost = _Customer.LivesInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string PackingLabel()
    {
        var label = "Packing Label:\n";
        foreach (var product in _Products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label.TrimEnd();
    }

    public string ShippingLabel()
    {
        var address = _Customer.GetAddress();
        return $"Shipping Label:\n{_Customer.GetName()}\n{address}";
    }
}