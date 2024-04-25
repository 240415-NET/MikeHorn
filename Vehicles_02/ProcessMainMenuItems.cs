
namespace Vehicles_02;

class ProcessMainMenuItems
{

    public void ListVehicles(List<Vehicle> Vehicles)
    {
        foreach(Vehicle v in Vehicles)
        {
            Console.WriteLine("Index = " + Vehicles.IndexOf(v) + " " + v);

        }
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

        Console.WriteLine("Vehicle has now been added");
    }
    public void BulkVehicles(List<Vehicle> Vehicles)
    {
        //vehicle 0
        Vehicles.Add(new Vehicle(1234, 2018, "Ford", "F150", true, Vehicles.Count()));

        //vehicle 1
        Vehicles.Add(new Vehicle(1234, 2015, "Honda", "Accord", true, Vehicles.Count()));

        //vehicle 2
        Vehicles.Add(new Vehicle(1234, 2010, "Volkswagon", "Jetta", true, Vehicles.Count()));

        //vehicle 3
        Vehicles.Add(new Vehicle(5678, 2020, "Honda", "Civic", true, Vehicles.Count()));

        Console.WriteLine("Bulk vehicles have been added");
    }

    public void RemoveVehicle(List<Vehicle> Vehicles, int intIndex)
    {
        Vehicles.RemoveAt(intIndex);

        Console.WriteLine("Vehicle has now been removed");
    }
    public void ToggleVehicleStatus(List<Vehicle> Vehicles, int intIndex)
    {
        bool blnVehStatus;
        blnVehStatus = Vehicles[intIndex].GetVehicleStatus();

        Vehicles[intIndex].SetVehicleStatus(Vehicle.Toggle_VehicleStatus(blnVehStatus));

        Console.WriteLine("Vehicle's Active Status has now been changed");
    }

}