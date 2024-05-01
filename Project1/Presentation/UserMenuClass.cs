
using Project1.Models;
using Project1.Controllers;
using Project1;
using System.Net;

namespace Project1.Presentation;
public class UserMenuClass
{
    public List<User> Users = new List<User>();
    private static bool Continue = true;

    public static void UserMenu()
    {
        string[] strMainMenuItems = { "exit", "list users", "enter user", "remove a user",  "enter bulk users" };
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strMainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strMainMenuItems))
            {
                // ProcessMainMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

    }

}