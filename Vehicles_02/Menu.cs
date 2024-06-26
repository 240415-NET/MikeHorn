namespace Vehicles_02;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Menu
{
    string? strMenuSelection;
    bool Continue = true;
    List<Vehicle> Vehicles = new List<Vehicle>();

    public void MainMenu()
    {
        string[] strMainMenuItems = { "exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status", "enter bulk vehicles" };
        List<string> MainMenuItems = new List<string>(strMainMenuItems);
        
        do
        {
            // Console.Clear();
            Console.WriteLine("Please enter the number of your selection:\n");
            PrintMenu(MainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(ValidateMenuInput(strMenuSelection, MainMenuItems))
            {
                ProcessMainMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

    }

    private static void PrintMenu(List<string> MenuItems)
    {
        foreach(string Item in MenuItems)
        {
            Console.WriteLine($"{MenuItems.IndexOf(Item)} - {MenuItems[MenuItems.IndexOf(Item)]}");
        }

    }

    public void ProcessMainMenu(int intMenuSelection)
    {
        ProcessMainMenuItems ProcessMenu = new();
        Console.WriteLine(" \n");

        try
        {
            switch (intMenuSelection)
            {
                case 0: //exit
                    Continue = false;
                    break;
                case 1: //list vehicles
                    ProcessMainMenuItems.ListVehicles(Vehicles);
                    break;
                case 2: //enter vehicle
                    ProcessMainMenuItems.EnterVehicle(Vehicles);
                    break;
                case 3: //remove a vehicle
                    Console.WriteLine("Please enter the Vehicle's Index Number to remove");
                    ProcessMainMenuItems.RemoveVehicle(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    break;
                case 4: //toggle vehicle's active status
                    Console.WriteLine("Please enter the Vehicle's Index Number to toggle its activate status");

                    ProcessMainMenuItems.ToggleVehicleStatus(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    break;
                case 5: //enter bulk vehicles
                    ProcessMainMenuItems.BulkVehicles(Vehicles);
                    break;
            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }

    static bool ValidateMenuInput(string MenuSelection, List<string> MenuItems)
    {
        try
        {
            if (Convert.ToInt16(MenuSelection) >= 0 && Convert.ToInt16(MenuSelection) <= MenuItems.Count() - 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Menu selection must be between 0 and {MenuItems.Count()-1}");
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