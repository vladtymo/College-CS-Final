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
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Discount: {Discount}%");
        Console.WriteLine($"Category: {Category}");
    }
}