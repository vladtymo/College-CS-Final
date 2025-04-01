using System.Text.Json;

namespace College_CS_Final;

public class Supermarket
{
    List<Product> items = new()
    {
        new Product() { Name = "Nike Bigsvoosh", Category = "Trainers", Price = 2500, Discount = 0, Quantity = 20 },
        new Product() { Name = "Knife", Category = "Kitchen Item", Price = 40, Discount = 5, Quantity = 2 },
        new Product() { Name = "PlayStation 6", Category = "Console", Price = 550, Discount = 10, Quantity = 3 },
    };

    List<Food> foods = new()
    {
        new Food()
        {
            Name = "Pizza", Category = "Food", Price = 25, Discount = 0, Quantity = 20, ExpirationDate = "10.4.2025",
            Components = "Cheese, Tomato"
        },
        new Food()
        {
            Name = "Watermelon", Category = "Fruit", Price = 10, Discount = 5, Quantity = 1,
            ExpirationDate = "4.8.2025", Components = "Water"
        },
    };

    public void AddNewProduct()
    {
        Product newItem = new();
        newItem.ReadFromConsole();
        items.Add(newItem);
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(items);
        File.WriteAllText("database.json", json);

        var json2 = JsonSerializer.Serialize(foods);
        File.WriteAllText("foods.json", json2);
    }

    public void Load()
    {
        var jsonData = File.ReadAllText("database.json");
        items = JsonSerializer.Deserialize<List<Product>>(jsonData);
			
        var jsonData2 = File.ReadAllText("foods.json");
        foods = JsonSerializer.Deserialize<List<Food>>(jsonData2);
        Console.WriteLine("All products have been saved!");
    }

    public void AddNewFood()
    {
        Food newfood = new();
        newfood.ReadFromConsole();
        foods.Add(newfood);
    }

    public void AllProducts()
    {
        foreach (Product item in items)
            item.Show();
    }

    public void AllFoods()
    {
        foreach (Food food in foods)
            food.Show();
    }

    public void FindProduct()
    {
        Console.Write("Enter product name to search: ");
        string name = Console.ReadLine();
			
        // логіка пошуку продукта
        var found = items.Find(x => x.Name == name);
        if (found == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }
			
        found.Show();
    }

    public void RemoveProduct()
    {
        Console.Write("Enter product name to delete: ");
        string name2 = Console.ReadLine();
			
        var found2 = items.Find(x => x.Name == name2);
        if (found2 == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }
			
        items.Remove(found2);
        Console.WriteLine($"Product {found2.Name} was removed successfuly!");
    }

    public void SellProduct()
    {
        Console.Write("Enter product name to buy: ");
        string name3 = Console.ReadLine();
			
        var prodToBuy = items.Find(x => x.Name == name3);
        if (prodToBuy == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }
			
        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        if (prodToBuy.Quantity < quantity)
        {
            Console.WriteLine($"Not enough quantity! We have only: {prodToBuy.Quantity}");
            return;
        }
			
        prodToBuy.Quantity -= quantity;
        Console.WriteLine($"Product {prodToBuy.Name} purchased successfully!");
    }
}