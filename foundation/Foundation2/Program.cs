using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Console.WriteLine("Hello Foundation2 World!");
        var usaAddress = new Address("123 Main St", "SpringVill", "UT ", "USA");
        var mxAddress = new Address("456 Calle Principal", "Mexico City", "CDMX", "Mexico");

       
        var customers = new List<Customer>
        {
            new Customer("John Doe", usaAddress),
            new Customer("Ana Pérez", mxAddress)
        };

     
        for (int i = 0; i < 2; i++)
        {
            var customer = customers[i];
            var order = new Order(customer);

            
            for (int j = 0; j < 2 + i; j++) 
            {
                var productName = $"Product {j + 1}";
                var productId = $"ID{random.Next(1000, 9999)}";
                var price = Math.Round((decimal)(random.NextDouble() * 20), 2);
                var quantity = random.Next(1, 5);

                var product = new Product(productName, productId, price, quantity);
                order.AddProduct(product);
            }

        
            Console.WriteLine(order.PackingLabel());
            Console.WriteLine(order.ShippingLabel());
            Console.WriteLine($"Total Cost: ${order.TotalCost():0.00}\n");
        }
    }
}