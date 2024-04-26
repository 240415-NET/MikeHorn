
namespace Vehicles_02;

class ProcessMainMenuItems
{

    public void ListVehicles(List<Vehicle> Vehicles)
    {
        foreach(Vehicle v in Vehicles)
        {
            Console.WriteLine("Index = " + Vehicles.IndexOf(v) + " " + v);
        }

        Console.WriteLine(" \n");
    }

    public void EnterVehicle(List<Vehicle> Vehicles)
    {
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

        Console.WriteLine("Vehicle has now been added \n");
    }
    public void BulkVehicles(List<Vehicle> Vehicles)
    {
        //Full Constructor
        //vehicle 0
        Vehicles.Add(new Vehicle(1234, 2018, "Ford", "F150", true, Vehicles.Count()));

        //vehicle 1
        Vehicles.Add(new Vehicle(1234, 2015, "Honda", "Accord", true, Vehicles.Count()));

        //vehicle 2
        Vehicles.Add(new Vehicle(1234, 2010, "Volkswagon", "Jetta", true, Vehicles.Count()));

        //vehicle 3
        Vehicles.Add(new Vehicle(5678, 2020, "Honda", "Civic", true, Vehicles.Count()));

        //Partial Constructor
        //Vehicle 4
        Vehicles.Add(new Vehicle(5678, 2014, "Acura", "ILX"));

        //Vehicle 5
        Vehicles.Add(new Vehicle(9876, 2016, "Hyundai", "Sonata"));

        //Trucks
        //Vehicle 6
        Vehicles.Add(new Truck(5670, 2020, "International", "LT625", true, 1, 18, "Car Carrier"));

        //Vehicle 7
        Vehicles.Add(new Truck(4687, 2024, "FREIGHTLINER", "114sd", true, 1, 6, "Cement Mixer"));

        //Vehicle 8
        Vehicles.Add(new Truck(1534, 2009, "WORKHORSE", "W62", true, 1, 4, "Cement Mixer"));

        Console.WriteLine("Bulk vehicles have been added \n");
    }

    public void RemoveVehicle(List<Vehicle> Vehicles, int intIndex)
    {
        Vehicles.RemoveAt(intIndex);

        Console.WriteLine("Vehicle has now been removed \n");
    }
    public void ToggleVehicleStatus(List<Vehicle> Vehicles, int intIndex)
    {
        bool blnVehStatus;
        blnVehStatus = Vehicles[intIndex].GetVehicleStatus();

        Vehicles[intIndex].SetVehicleStatus(Vehicle.Toggle_VehicleStatus(blnVehStatus));

        Console.WriteLine("Vehicle's Active Status has now been changed \n");
    }

}