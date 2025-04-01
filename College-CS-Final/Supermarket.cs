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
        new Food() { Name = "Pizza", Category = "Food", Price = 25, Discount = 0, Quantity = 20, ExpirationDate = "10.4.2025", Components="Cheese, Tomato"},
        new Food() { Name = "Watermelon", Category = "Fruit", Price = 10, Discount = 5, Quantity = 1, ExpirationDate = "4.8.2025", Components="Water" },
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
}