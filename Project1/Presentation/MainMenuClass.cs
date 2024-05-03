
using Project1.Models;
using Project1.Controllers;
using Project1;
using System.Net;

namespace Project1.Presentation;
public class MainMenuClass
{
    public List<Vehicle> Vehicles = new List<Vehicle>();
    private static bool Continue = true;

    public void MainMenu()
    {
        string[] strMainMenuItems = { "exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status", "manage users", "enter bulk vehicles" };
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strMainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strMainMenuItems))
            {
                ProcessMainMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

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
                    foreach(Vehicle v in Vehicles)
                    {
                        Console.WriteLine("Index = " + Vehicles.IndexOf(v) + " " + v);
                    }

                    Console.WriteLine(" \n");
                    break;
                case 2: //enter vehicle
                    AddVehicle(Vehicles);

                    Console.WriteLine("Vehicle has now been added \n");

                    break;
                case 3: //remove a vehicle
                    Console.WriteLine("Please enter the Vehicle's Index Number to remove");
                    ProcessMainMenuItems.RemoveVehicle(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle has now been removed \n");

                    break;
                case 4: //toggle vehicle's active status
                    Console.WriteLine("Please enter the Vehicle's Index Number to toggle its activate status");

                    ProcessMainMenuItems.ToggleVehicleStatus(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle's Active Status has now been changed \n");

                    break;
                case 5: //manage users
                    UserMenuClass.UserMenu();
                    break;
                case 6: //enter bulk vehicles
                    ProcessMainMenuItems.BulkVehicles(Vehicles);

                    Console.WriteLine("Bulk vehicles have been added \n");

                    break;
            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }

    public static void AddVehicle(List<Vehicle> Vehicles)
    {
        Vehicles.Add(new Vehicle());

        Console.WriteLine("Please enter the Policy Id");
        Vehicles[Vehicles.Count - 1].SetPolicyId(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Year");
        Vehicles[Vehicles.Count - 1].Setyear(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Make");
        Vehicles[Vehicles.Count - 1].Setmake(Console.ReadLine());

        Console.WriteLine("Please enter the Vehicle's Model");
        Vehicles[Vehicles.Count - 1].Setmodel(Console.ReadLine());

        Vehicles[Vehicles.Count - 1].SetVehicleStatus(true);

        Vehicles[Vehicles.Count - 1].SetVehicleNumber(Vehicles.Count);
    }

}
