// 1. ------------------- Супермаркет
/* Створити ієрархію класів для продажу товарів Супермаркету
	Продукт(назва, термін споживання, категорія - молочні. хлібобулочні та ін., ціна, кількість)
	Товар (назва, категорія - побутова хімія, текстиль та ін., ціна, кількість)
Створити програму для роботи Супермаркету
	Додавання продукту(товару) у базу(врахувати, що товар у базі може бути наявний або ні)
	Збереження бази товарів(у файл)
	Завантаження бази товарів з файлу
	Перегляд продуктів(товарів), впорядкованих по категоріях
	Пошук певного товару(продукту) з видачею інформації про товар(продукт)
	Видалення певного товару(продукту) з бази
	Продаж товару(з видачею чеку)
*/

using System.Text.Json;

Console.OutputEncoding = System.Text.Encoding.UTF8; // для укр мови

List<Product> items = new()
{
	new Product() { Name = "Nike Bigsvoosh", Category = "Trainers", Price = 2500, Discount = 0, Quantity = 20 },
	new Product() { Name = "Knife", Category = "Kitchen Item", Price = 40, Discount = 5, Quantity = 220 },
	new Product() { Name = "PlayStation 6", Category = "Console", Price = 550, Discount = 10, Quantity = 3 },
};
List<Food> foods = new()
{
	new Food() { Name = "Pizza", Category = "Food", Price = 25, Discount = 0, Quantity = 20, ExpirationDate = "10.4.2025", Components="Cheese, Tomato"},
	new Food() { Name = "Watermelon", Category = "Fruit", Price = 10, Discount = 5, Quantity = 1, ExpirationDate = "4.8.2025", Components="Water" },
};

while (true)
{
	Console.Clear(); // очищення консолі
	Console.WriteLine("------------- Welcome to Supermarket! -------------");

	Console.WriteLine("\tADMIN MENU\n" +
	                  "1. Add New Product\n" +
	                  "12. Add New Food\n" +
	                  "2. Save Products\n" +
	                  "3. Load Products\n" +
	                  "4. Show All Products\n" +
	                  "42. Show All Foods\n" +
	                  "5. Find Product\n" +
	                  "6. Delete Product\n" +
	                  "7. Sell Product");
	Console.WriteLine("______________________________");
	
	Console.Write("Your choice: ");
	int choice = int.Parse(Console.ReadLine());
	
	switch (choice)
	{
		case 1:
			Product newItem = new();
			newItem.ReadFromConsole();
			items.Add(newItem);
			break;
		case 2:
			var json = JsonSerializer.Serialize(items);
			File.WriteAllText("database.json", json);
			
			var json2 = JsonSerializer.Serialize(foods);
			File.WriteAllText("foods.json", json2);
			break;
		case 3:
			var jsonData = File.ReadAllText("database.json");
			items = JsonSerializer.Deserialize<List<Product>>(jsonData);
			
			var jsonData2 = File.ReadAllText("foods.json");
			foods = JsonSerializer.Deserialize<List<Food>>(jsonData2);
			break;
		case 12:
			Food newfood = new();
			newfood.ReadFromConsole();
			foods.Add(newfood);
			break;
		case 4:
			foreach (Product item in items)
				item.Show();
			break;
		case 42:
			foreach (Food food in foods)
				food.Show();
			break;
		case 5:
			Console.Write("Enter product name to search: ");
			string name = Console.ReadLine();
			
			// логіка пошуку продукта
			var found = items.Find(x => x.Name == name);
			if (found == null)
			{
				Console.WriteLine("Product not found!");
				break;
			}
			
			found.Show();
			break;
		case 6:
			Console.Write("Enter product name to delete: ");
			string name2 = Console.ReadLine();
			
			var found2 = items.Find(x => x.Name == name2);
			if (found2 == null)
			{
				Console.WriteLine("Product not found!");
				break;
			}
			
			items.Remove(found2);
			break;
	}

	Console.WriteLine("Натистінь щось для продовження...");
	Console.ReadKey();
}

public class Product
{
	// властивості продукта
	public string Name { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public int Quantity { get; set; }
	public int Discount { get; set; }
	public string Category { get; set; }

	public void ReadFromConsole()
	{
		Console.Write("Enter name: ");
		Name = Console.ReadLine();
		Console.Write("Enter price: ");
		Price = double.Parse(Console.ReadLine());
		Console.Write("Enter description: ");
		Description = Console.ReadLine();
		Console.Write("Enter quantity: ");
		Quantity = int.Parse(Console.ReadLine());
		Console.Write("Enter discount: ");
		Discount = int.Parse(Console.ReadLine());
		Console.Write("Enter category: ");
		Category = Console.ReadLine();
	}
	
	public void Show()
	{
		Console.WriteLine("------ Product ------");
		Console.WriteLine($"Name: {Name}");
		Console.WriteLine($"Price: {Price}$");
		Console.WriteLine($"Quantity: {Quantity}$");
		Console.WriteLine($"Discount: {Discount}%");
		Console.WriteLine($"Category: {Category}");
	}
}

public class Food : Product
{
	// властивості продукта
	public string ExpirationDate { get; set; }
	public string Components { get; set; }
    
	public void ReadFromConsole()
	{
		Console.Write("Enter name: ");
		Name = Console.ReadLine();
		Console.Write("Enter price: ");
		Price = double.Parse(Console.ReadLine());
		Console.Write("Enter description: ");
		Description = Console.ReadLine();
		Console.Write("Enter quantity: ");
		Quantity = int.Parse(Console.ReadLine());
		Console.Write("Enter discount: ");
		Discount = int.Parse(Console.ReadLine());
		Console.Write("Enter category: ");
		Category = Console.ReadLine();
		Console.Write("Enter expiration: ");
		ExpirationDate = Console.ReadLine();
		Console.Write("Enter components: ");
		Components = Console.ReadLine();
	}
	
	public void Show()
	{
		Console.WriteLine("------ Product ------");
		Console.WriteLine($"Name: {Name}");
		Console.WriteLine($"Price: {Price}$");
		Console.WriteLine($"Quantity: {Quantity}$");
		Console.WriteLine($"Discount: {Discount}%");
		Console.WriteLine($"Category: {Category}");
		Console.WriteLine($"Expiration: {ExpirationDate}");
		Console.WriteLine($"Components: {Components}");
	}
}