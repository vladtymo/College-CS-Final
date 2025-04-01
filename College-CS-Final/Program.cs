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



while (true)
{
	Console.Clear(); // очищення консолі
	Console.WriteLine("------------- Welcome to Supermarket! -------------");

	Console.WriteLine("\tADMIN MENU\n" +
	                  "0. Exit\n" +
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
		case 0:
			Console.WriteLine("Have a good day!");
			return 0;
		case 1:
			
			break;
		case 2:
			
			Console.WriteLine("All products loaded!");
			break;
		case 3:
			var jsonData = File.ReadAllText("database.json");
			items = JsonSerializer.Deserialize<List<Product>>(jsonData);
			
			var jsonData2 = File.ReadAllText("foods.json");
			foods = JsonSerializer.Deserialize<List<Food>>(jsonData2);
			Console.WriteLine("All products have been saved!");
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
			Console.WriteLine($"Product {found2.Name} was removed successfuly!");
			break;
		case 7:
			Console.Write("Enter product name to buy: ");
			string name3 = Console.ReadLine();
			
			var prodToBuy = items.Find(x => x.Name == name3);
			if (prodToBuy == null)
			{
				Console.WriteLine("Product not found!");
				break;
			}
			
			Console.Write("Enter quantity: ");
			int quantity = int.Parse(Console.ReadLine());

			if (prodToBuy.Quantity < quantity)
			{
				Console.WriteLine($"Not enough quantity! We have only: {prodToBuy.Quantity}");
				break;
			}
			
			prodToBuy.Quantity -= quantity;
			Console.WriteLine($"Product {prodToBuy.Name} purchased successfully!");
			break;
	}

	Console.WriteLine("Натистінь щось для продовження...");
	Console.ReadKey();
}