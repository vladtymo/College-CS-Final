﻿// 1. ------------------- Супермаркет
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
using College_CS_Final;

Console.OutputEncoding = System.Text.Encoding.UTF8; // для укр мови

Menu menu = new();
Supermarket supermarket = new();

while (true)
{
	Console.Clear(); // очищення консолі
	Console.WriteLine("------------- Welcome to Supermarket! -------------");

	menu.ShowMenu();
	int choice = menu.AskUserInput();
	
	switch (choice)
	{
		case 0: Console.WriteLine("Have a good day!");
			return 0;
		case 1: supermarket.AddNewProduct(); break;
		case 2:
			supermarket.Save();
			Console.WriteLine("All products loaded!");
			break;
		case 3: supermarket.Load(); break;
		case 12: supermarket.AddNewFood(); break;
		case 4: supermarket.AllProducts(); break;
		case 42: supermarket.AllFoods(); break;
		case 5: supermarket.FindProduct(); break;
		case 6: supermarket.RemoveProduct(); break;
		case 7: supermarket.SellProduct(); break;
	}

	Console.WriteLine("Натистінь щось для продовження...");
	Console.ReadKey();
}