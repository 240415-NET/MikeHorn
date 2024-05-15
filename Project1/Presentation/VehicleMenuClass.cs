using Project1.Models;
using Project1.Controllers;

namespace Project1.Presentation;
public class VehicleMenuClass
{
    public static List<Vehicle> Vehicles = new List<Vehicle>();
    private static bool Continue = true;

    public static string[] strVehicleMenuItems;

    public static void VehicleMenu(string _UserRole, bool isTest = false)
    {

        if(_UserRole == "Admin")
        {
            strVehicleMenuItems = ["exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status", "add bulk" ];
        }else
        {
            strVehicleMenuItems = [ "exit", "list vehicles", "enter vehicle", "remove a vehicle", "toggle vehicle's active status" ];
        }

        if(isTest)
        {
            return;
        }
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strVehicleMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strVehicleMenuItems))
            {
                ProcessVehicleMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

    }


    public static void ProcessVehicleMenu(int intMenuSelection)
    {
        ProcessVehicleMenuItems ProcessMenu = new();
        VehiclesDTO VehiclesObject = new();

        Console.WriteLine(" \n");

        try
        {
            switch (intMenuSelection)
            {
                case 0: //exit
                    Continue = false;
                    break;
                case 1: //list vehicles

                    VehiclesObject = ProcessVehicleMenuItems.GetVehicles(VehiclesObject);

                    if(VehiclesObject != null)
                    {

                        foreach(Vehicle v in VehiclesObject.Cars)
                        {
                            Console.WriteLine($"Index = {VehiclesObject.Cars.IndexOf(v)} {v}");
                        }
                        foreach(Truck v in VehiclesObject.Trucks)
                        {
                            Console.WriteLine($"Index = {VehiclesObject.Trucks.IndexOf(v) + VehiclesObject.Cars.Count} {v}");
                        }
                    }else
                    {
                        Console.WriteLine("No vehicles found");
                    }

                    Console.WriteLine(" \n");
                    break;

                case 2: //enter vehicle

                    // AddVehicle();
                    Console.WriteLine("Is this vehicle a truck? (y/n)");


                    AddVehicleQuestions(Console.ReadLine().ToLower() == "y");

                    Console.WriteLine("Vehicle has now been added \n");

                    break;
                case 3: //remove a vehicle
                    VehiclesObject = ProcessVehicleMenuItems.GetVehicles(VehiclesObject);

                    Console.WriteLine("Please enter the Vehicle's Index Number to remove");
                    ProcessVehicleMenuItems.RemoveVehicle(VehiclesObject, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle has now been removed \n");

                    break;
                case 4: //toggle vehicle's active status
                    VehiclesObject = ProcessVehicleMenuItems.GetVehicles(VehiclesObject);
                    Console.WriteLine("Please enter the Vehicle's Index Number to toggle its activate status");

                    ProcessVehicleMenuItems.ToggleVehicleStatus(VehiclesObject, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("Vehicle's Active Status has now been changed \n");

                    break;
                case 5:
                    ProcessVehicleMenuItems.BulkVehicles();
                    break;

            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }


    public static void AddVehicleQuestions(bool isTruck)
    {
        List<string> addVehicleAnswers = new();

        Console.WriteLine("Please enter the Policy Id");
        addVehicleAnswers.Add(Console.ReadLine()); // index 0

        Console.WriteLine("Please enter the Vehicle's Year");
        addVehicleAnswers.Add(Console.ReadLine()); // index 1

        Console.WriteLine("Please enter the Vehicle's Make");
        addVehicleAnswers.Add(Console.ReadLine()); // index 2

        Console.WriteLine("Please enter the Vehicle's Model");
        addVehicleAnswers.Add(Console.ReadLine()); // index 3

        if(isTruck == true)//vehicle is a truck
        {
            Console.WriteLine("Please enter the number of wheels on the truck");
            addVehicleAnswers.Add(Console.ReadLine()); // index 4

            // Console.WriteLine("What is the truck type?");
            addVehicleAnswers.Add(TruckTypeMenu()); // index 5

            ProcessVehicleMenuItems.AddTruck(addVehicleAnswers);
        }else
        {
            ProcessVehicleMenuItems.AddVehicle(addVehicleAnswers);
        }

    }

    public static string TruckTypeMenu()
    {
        Continue = true;
        string[] strTruckTypes;
        strTruckTypes = ["Car Carrier", "Cement Mixer", "Flatbed Truck", "Garbage Truck", "Refrigerated Truck", "Tow Truck - one axle", "Tow Truck- two axle"];

        do
        {
            Console.WriteLine("Please enter the number of the Truck Type:\n");
            MenuClass.PrintMenu(strTruckTypes);
            string strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strTruckTypes))
            {
                // ProcessVehicleMenu(Convert.ToInt16(strMenuSelection));
                return strTruckTypes[Convert.ToInt16(strMenuSelection)];
            }
        }while (Continue);

        return "Flatbed Truck";
    }
   
}