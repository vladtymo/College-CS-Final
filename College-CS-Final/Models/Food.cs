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