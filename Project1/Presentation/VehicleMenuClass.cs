using Project1.Models;
using Project1.Controllers;

namespace Project1.Presentation;
public class VehicleMenuClass
{
    public static List<Vehicle> Vehicles = new List<Vehicle>();
    private static bool Continue = true;

    public static void VehicleMenu()
    {
        // string[] strMainMenuItems = { "exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status", "add bulk" };
        string[] strMainMenuItems = { "exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status" };
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strMainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strMainMenuItems))
            {
                ProcessVehicleMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

    }


    public static void ProcessVehicleMenu(int intMenuSelection)
    {
        ProcessVehicleMenuItems ProcessMenu = new();
        Console.WriteLine(" \n");

        try
        {
            switch (intMenuSelection)
            {
                case 0: //exit
                    Continue = false;
                    break;
                case 1: //list vehicles

                    Vehicles = ProcessVehicleMenuItems.GetVehicles(Vehicles);

                    if(Vehicles != null)
                    {

                        foreach(Vehicle v in Vehicles)
                        {
                            Console.WriteLine("Index = " + Vehicles.IndexOf(v) + " " + v);
                        }
                    }else
                    {
                        Console.WriteLine("No vehicles found");
                    }

                    Console.WriteLine(" \n");
                    break;

                case 2: //enter vehicle

                    AddVehicle();

                    Console.WriteLine("Vehicle has now been added \n");

                    break;
                case 3: //remove a vehicle
                    Console.WriteLine("Please enter the Vehicle's Index Number to remove");
                    ProcessVehicleMenuItems.RemoveVehicle(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle has now been removed \n");

                    break;
                case 4: //toggle vehicle's active status
                    Console.WriteLine("Please enter the Vehicle's Index Number to toggle its activate status");

                    ProcessVehicleMenuItems.ToggleVehicleStatus(Vehicles, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle's Active Status has now been changed \n");

                    break;
                // case 5:
                //     ProcessVehicleMenuItems.BulkVehicles(Vehicles);
                //     break;

            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }

    public static void AddVehicle()
    {
        List<Vehicle> addedVehicle = new();

        addedVehicle.Add(new Vehicle());


        Console.WriteLine("Please enter the Policy Id");
        addedVehicle[0].SetPolicyId(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Year");
        addedVehicle[0].Setyear(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Make");
        addedVehicle[0].Setmake(Console.ReadLine());

        Console.WriteLine("Please enter the Vehicle's Model");
        addedVehicle[0].Setmodel(Console.ReadLine());

        addedVehicle[0].SetVehicleStatus(true);

        addedVehicle[0].SetVehicleId();

        ProcessVehicleMenuItems.SetVehicles(addedVehicle);
    }
}