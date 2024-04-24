namespace IntroClass;

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
                            Vehicles[Vehicles.Count() - 1].PolicyId = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("Please enter the Vehicle's Year");
                            Vehicles[Vehicles.Count() - 1].year = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("Please enter the Vehicle's Make");
                            Vehicles[Vehicles.Count() - 1].make = Console.ReadLine();

                            Console.WriteLine("Please enter the Vehicle's Model");
                            Vehicles[Vehicles.Count() - 1].model = Console.ReadLine();

                            Vehicles[Vehicles.Count() - 1].Active = true;

                            break;
                        case 2: //toggle vehicle's active status
                            Console.WriteLine("Please enter the Vehicle's Indes Number to toggle its activate status");
                            int intIndex2;
                            intIndex2 = Convert.ToInt16(Console.ReadLine());
                            Vehicles[intIndex2].Active = Vehicle.Toggle_Active(Vehicles[intIndex2].Active);
                            break;
                        case 3: //list vehicles
                            int intI1 = 0;
                            foreach(Vehicle v in Vehicles)
                            {
                                string strActive = "Active";
                                if(!v.Active)
                                {
                                    strActive = "Deactive";
                                }
                                Console.WriteLine($"Index = {intI1} Policy {v.PolicyId} Year {v.year} Make {v.make} Model {v.model} Active {strActive}");
                                intI1++;
                            }
                            break;
                        case 4: //remove a vehicle
                            Console.WriteLine("Please enter the Vehicle's Indes Number to remove");
                            Vehicles.RemoveAt(Convert.ToInt16(Console.ReadLine()));
                            break;
                        case 5: //enter bulk vehicles
                            //vehicle 0
                            Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2018, make = "Ford", model = "F150", Active = true});

                            //vehicle 1
                            Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2015, make = "Honda", model = "Accord", Active = true});

                            //vehicle 2
                            Vehicles.Add(new Vehicle() {PolicyId = 1234, year = 2010, make = "Volkswagon", model = "Jetta", Active = true});

                            //vehicle 3
                            Vehicles.Add(new Vehicle() {PolicyId = 5678, year = 2020, make = "Honda", model = "Civic", Active = true});

                            break;
                        case 6: //search
                            int intIndex;
                            string strMake;
                            Console.WriteLine("What are you searching for?");
                            strMake = Console.ReadLine().ToLower();
                            intIndex = Vehicles.FindIndex(f => f.make.ToLower().Equals(strMake));

                            Console.Write($"The Make {strMake} is found at Index {intIndex} ");

                            break;
                        case 7: //search with LINQ
                            
                            Console.WriteLine("What are you searching for?");
                            strMake = Console.ReadLine().ToLower();

                            // LINQ Query
                            var subsetVehicles = from theVehicle in Vehicles
                                        where theVehicle.make.ToLower() == strMake
                                        select theVehicle;
                            
                            foreach(Vehicle theVehicle in subsetVehicles)
                            {
                                Console.WriteLine($"Policy {theVehicle.PolicyId} Year {theVehicle.year} Make {theVehicle.make} Model {theVehicle.model} Active {theVehicle.Active}");
                            }

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
