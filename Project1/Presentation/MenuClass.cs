using Project1.Models;
using Project1.Controllers;
using Project1;
using System.Net;

namespace Project1.Presentation;
public class MenuClass
{
    public static void PrintMenu(string[] MenuItems)
    {
        foreach(string Item in MenuItems)
        {
            Console.WriteLine($"{Array.IndexOf(MenuItems, Item)} - {MenuItems[Array.IndexOf(MenuItems, Item)]}");
        }

    }

    public static bool ValidateMenuInput(string MenuSelection, string[] MenuItems)
        {
            try
            {
                if (Convert.ToInt16(MenuSelection) >= 0 && Convert.ToInt16(MenuSelection) <= MenuItems.Count() - 1)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Menu selection must be between 0 and {MenuItems.Length - 1}");
                    return false;
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine($"Error detected {excp.Message}");
                return false;
            }
        }
}