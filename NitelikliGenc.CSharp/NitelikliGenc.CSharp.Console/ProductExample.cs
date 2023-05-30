using System;
using System.Collections.Generic;
using System.Linq;

namespace NitelikliGenc.CSharp.Console;

public class ProductExample
{
    private readonly Dictionary<Guid, int> _prices = new();
    
    public void WriteProducts()
    {
        var products = new List<Product>();
        
        try
        {
            products = CreateAndGetProducts();
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Error message " + e.Message);
            System.Console.WriteLine("Ürün oluşturulamadı!"); 
        }
        finally
        {
            System.Console.WriteLine("İşlem tamamlandı.");
        }
        
        foreach (var product in products)
        {
            var price = _prices.FirstOrDefault(x => x.Key == product.Id);
            
            System.Console.WriteLine("*");
            System.Console.WriteLine("Category Name - Product Name - Price");
            System.Console.WriteLine(product.Category.Name + " - " + product.Name + " - " + price.Value);
        }
    }
    
    private List<Product> CreateAndGetProducts()
    {
        var rnd = new Random();
        
        var categories = CreateAndGetCategories();
        var products = new List<Product>();

        System.Console.Write("Kaç tane ürün oluşturmak istersiniz ?");
        var productCount = int.Parse(System.Console.ReadLine() ?? string.Empty);

        for (var i = 0; i < productCount; i++)
        {
            var category = i % 2 == 0 ? categories[0] : categories[1];

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Category = category,
                Name = category.Name + "_" + i
            };
            products.Add(product);
            
            _prices.Add(product.Id, rnd.Next(129, 999));
        }
        return products;
    }

    private List<Category> CreateAndGetCategories()
    {
        var categories = new List<Category>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "PersonalComputer"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "MobilePhone"
            }
        };
        return categories;
    }
}

public class Product : BaseModel
{
    public string Name { get; set; }
    public Category Category { get; set; }
}
public class Category : BaseModel
{
    public string Name { get; set; }
}
public class BaseModel
{
    public Guid Id { get; set; }
}