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
                    3 - list vehicles");

                    intMenuResponse = Convert.ToInt16(Console.ReadLine());

                    //switch
                    switch (intMenuResponse)
                    {
                        case 0:
                            repeat = false;
                            break;
                        case 1:
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
                        case 2:
                            Console.WriteLine("Please enter the Vehicle's Indes Number to deactivate");
                            Vehicles[Convert.ToInt16(Console.ReadLine())].Active = false;
                            break;
                        case 3:
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
