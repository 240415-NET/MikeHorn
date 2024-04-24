﻿namespace Vehicles_02;

using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool repeat = true;
        bool blnCorrect = true;
        List<Vehicle> Vehicles = new List<Vehicle>();

        do
        {
            try
            {
                while (repeat)
                {
                    //display menu and get response
                    int intMenuResponse = 0;

                    Console.WriteLine(@"What would you like to do?
                    0 - exit
                    1 - enter vehicle
                    2 - toggle vehicle's active status
                    3 - list vehicles
                    4 - remove a vehicle
                    5 - enter bulk vehicles
                    6 - search
                    7 - search with LINQ");

                    intMenuResponse = Convert.ToInt16(Console.ReadLine());

                    //switch
                    switch (intMenuResponse)
                    {
                        case 0: //exit
                            repeat = false;
                            blnCorrect = false;
                            break;
                        case 1: //enter vehicle
                            Vehicles.Add(new Vehicle());

                            Console.WriteLine("Please enter the Policy Id");
                            Vehicles[Vehicles.Count() - 1].SetPolicyId(Convert.ToInt16(Console.ReadLine()));

                            Console.WriteLine("Please enter the Vehicle's Year");
                            Vehicles[Vehicles.Count() - 1].Setyear(Convert.ToInt16(Console.ReadLine()));

                            Console.WriteLine("Please enter the Vehicle's Make");
                            Vehicles[Vehicles.Count() - 1].Setmake(Console.ReadLine());

                            Console.WriteLine("Please enter the Vehicle's Model");
                            Vehicles[Vehicles.Count() - 1].Setmodel(Console.ReadLine());

                            Vehicles[Vehicles.Count() - 1].SetVehicleStatus(true);

                            Vehicles[Vehicles.Count() - 1].SetVehicleNumber(Vehicles.Count());


                            break;
                        case 2: //toggle vehicle's active status
                            Console.WriteLine("Please enter the Vehicle's Indes Number to toggle its activate status");
                            int intIndex2;
                            bool blnVehStatus;

                            intIndex2 = Convert.ToInt16(Console.ReadLine());

                            blnVehStatus = Vehicles[intIndex2].GetVehicleStatus();

                            Vehicles[intIndex2].SetVehicleStatus(Vehicle.Toggle_VehicleStatus(blnVehStatus));

                            break;
                        case 3: //list vehicles
                            int intI1 = 0;
                            foreach(Vehicle v in Vehicles)
                            {
                                Console.WriteLine ("Index = " + intI1 + " " + v);
                                // string strActive = "Active";
                                // if(!v.Active)
                                // {
                                //     strActive = "Deactive";
                                // }
                                // Console.WriteLine($"Index = {intI1} Policy {v.PolicyId} Year {v.year} Make {v.make} Model {v.model} Active {strActive}");
                                intI1++;
                            }
                            break;
                        case 4: //remove a vehicle
                            Console.WriteLine("Please enter the Vehicle's Index Number to remove");
                            Vehicles.RemoveAt(Convert.ToInt16(Console.ReadLine()));
                            break;
                        case 5: //enter bulk vehicles
                            //vehicle 0
                            // Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2018, make = "Ford", model = "F150", Active = true});
                            Vehicles.Add(new Vehicle(1234, 2018, "Ford", "F150", true, Vehicles.Count()));

                            //vehicle 1
                            // Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2015, make = "Honda", model = "Accord", Active = true});
                            Vehicles.Add(new Vehicle(1234, 2015, "Honda", "Accord", true, Vehicles.Count()));

                            //vehicle 2
                            // Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2010, make = "Volkswagon", model = "Jetta", Active = true});
                            Vehicles.Add(new Vehicle(1234, 2010, "Volkswagon", "Jetta", true, Vehicles.Count()));

                            //vehicle 3
                            // Vehicles.Add(new Vehicle() {PolicyId = 5678, year = 2020, make = "Honda", model = "Civic", Active = true});
                            Vehicles.Add(new Vehicle(5678, 2020, "Honda", "Civic", true, Vehicles.Count()));

                            break;
                        case 6: //search
                            // int intIndex;
                            // string strMake;
                            // Console.WriteLine("What are you searching for?");
                            // strMake = Console.ReadLine().ToLower();
                            // intIndex = Vehicles.FindIndex(f => f.make.ToLower().Equals(strMake));

                            // Console.Write($"The Make {strMake} is found at Index {intIndex} ");

                            break;
                        case 7: //search with LINQ
                            
                            // Console.WriteLine("What are you searching for?");
                            // strMake = Console.ReadLine().ToLower();

                            // // LINQ Query
                            // var subsetVehicles = from theVehicle in Vehicles
                            //             where theVehicle.make.ToLower() == strMake
                            //             select theVehicle;

                            // foreach(Vehicle theVehicle in subsetVehicles)
                            // {
                            //     Console.WriteLine($"Policy {theVehicle.PolicyId} Year {theVehicle.year} Make {theVehicle.make} Model {theVehicle.model} Active {theVehicle.Active}");
                            // }

                            break;

                    }

                }

            }catch(Exception excp)
            {
                Console.WriteLine($"Error detected {excp.Message}");
                blnCorrect = false;

            }
        }while(blnCorrect);

 
    }
}

