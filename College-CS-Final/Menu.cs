namespace College_CS_Final;

public class Menu
{
    public void ShowAdminMenu()
    {
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
    }
    public void ShowUserMenu()
    {
        Console.WriteLine("\tUSER MENU\n" +
                          "0. Exit\n" +
                          "1. Buy Product");
        Console.WriteLine("______________________________");
    }
    public void ShowLoginMenu()
    {
        Console.WriteLine("\tCHOOSE YOUR ROLE\n" +
                          "0. Exit\n" +
                          "1. User\n" +
                          "2. Admin\n");
        Console.WriteLine("______________________________");
    }

    public int AskUserInput()
    {
        Console.Write("Your choice: "); 
        return int.Parse(Console.ReadLine());
    }
}