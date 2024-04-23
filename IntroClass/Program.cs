namespace IntroClass;

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
                    2 - deactivate vehicle
                    3 - list vehicles
                    4 - enter bulk vehicles");

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
                        case 2: //deactivate vehicle
                            Console.WriteLine("Please enter the Vehicle's Indes Number to deactivate");
                            Vehicles[Convert.ToInt16(Console.ReadLine())].Active = false;
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
                        case 4: //enter bulk vehicles
                            //vehicle 0
                            Vehicles.Add(new Vehicle());
                            Vehicles[0].PolicyId = 1234;
                            Vehicles[0].year = 2018;
                            Vehicles[0].make = "Ford";
                            Vehicles[0].model = "F150";
                            Vehicles[0].Active = true;

                            //vehicle 1
                            Vehicles.Add(new Vehicle());
                            Vehicles[1].PolicyId = 1234;
                            Vehicles[1].year = 2015;
                            Vehicles[1].make = "Honda";
                            Vehicles[1].model = "Accord";
                            Vehicles[1].Active = true;

                            //vehicle 2
                            Vehicles.Add(new Vehicle());
                            Vehicles[2].PolicyId = 1234;
                            Vehicles[2].year = 2010;
                            Vehicles[2].make = "Volkswagon";
                            Vehicles[2].model = "Jetta";
                            Vehicles[2].Active = true;

                            //vehicle 3
                            Vehicles.Add(new Vehicle());
                            Vehicles[3].PolicyId = 5678;
                            Vehicles[3].year = 2020;
                            Vehicles[3].make = "Honda";
                            Vehicles[3].model = "Civic";
                            Vehicles[3].Active = true;

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
