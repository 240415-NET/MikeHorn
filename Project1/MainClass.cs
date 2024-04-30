namespace Project1;

using Project1.Presentation;

class MainClass
{
    static void Main(string[] args)
    {
        Console.Clear();

        Menu StartMenu = new();
        StartMenu.MainMenu();
    }
}
