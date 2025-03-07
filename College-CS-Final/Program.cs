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

Console.OutputEncoding = System.Text.Encoding.UTF8; // для укр мови
Console.Clear(); // очищення консолі

Console.WriteLine("------------- Welcome to Supermarket! -------------");

Console.WriteLine("\tADMIN MENU\n" +
                  "1. Add New Product\n" +
                  "2. Save Products\n" +
                  "3. Load Products\n" +
                  "4. Show All Products\n" +
                  "5. Find Product\n" +
                  "6. Delete Product\n" +
                  "7. Sell Product");
Console.WriteLine("______________________________");

Console.Write("Your choice: ");
int choice = int.Parse(Console.ReadLine());

Product item = new Product();

switch (choice)
{
	case 1:
		item.Name = Console.ReadLine();
		item.Description = Console.ReadLine();
		item.Price = double.Parse(Console.ReadLine());
		item.Quantity = int.Parse(Console.ReadLine());
		item.Discount = int.Parse(Console.ReadLine());
		item.Category = Console.ReadLine();
		break;
	case 4:
		Console.WriteLine($"Name: {item.Name}");
		Console.WriteLine($"Price: {item.Price}$");
		break;
}

public class Product
{
	// властивості продукта
	public string Name { get; set; }
	public string? Description { get; set; }
	public double Price { get; set; }
	public int Quantity { get; set; }
	public int Discount { get; set; }
	public string Vendor { get; set; }
	public string Category { get; set; }
}

public class Food : Product
{
	// властивості продукта
	public string ExpirationDate { get; set; }
	public string Components { get; set; }
}