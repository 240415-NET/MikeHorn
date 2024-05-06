using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;

class ProcessMainMenuItems
{
    public static IVehicleDataManagement VehicleStore = new VehicleStorageJSON();

    public static List<Vehicle> GetVehicles(List<Vehicle> Vehicles)
    {
        Vehicles = VehicleStore.RetrieveData(Vehicles);
        return Vehicles;
    }

    public static void SetVehicles(List<Vehicle> Vehicles)
    {

        VehicleStore.StoreData(Vehicles, true);
    }

    public static void RemoveVehicle(List<Vehicle> Vehicles, int intIndex)
    {
        Vehicles.RemoveAt(intIndex);

        VehicleStore.StoreData(Vehicles, true);

    }
    public static void ToggleVehicleStatus(List<Vehicle> Vehicles, int intIndex)
    {
        bool blnVehStatus;
        blnVehStatus = Vehicles[intIndex].GetVehicleStatus();

        Vehicles[intIndex].SetVehicleStatus(Vehicle.Toggle_VehicleStatus(blnVehStatus));

        VehicleStore.StoreData(Vehicles, true);

    }

    //Obsolete
    // public static void BulkVehicles(List<Vehicle> Vehicles)
    // {
    //     //Full Constructor
    //     //vehicle 0
    //     Vehicles.Add(new Vehicle(1234, 2018, "Ford", "F150", true, Vehicles.Count));

    //     //vehicle 1
    //     Vehicles.Add(new Vehicle(1234, 2015, "Honda", "Accord", true, Vehicles.Count));

    //     //vehicle 2
    //     Vehicles.Add(new Vehicle(1234, 2010, "Volkswagon", "Jetta", true, Vehicles.Count));

    //     //vehicle 3
    //     Vehicles.Add(new Vehicle(5678, 2020, "Honda", "Civic", true, Vehicles.Count));

    //     //Partial Constructor
    //     //Vehicle 4
    //     Vehicles.Add(new Vehicle(5678, 2014, "Acura", "ILX"));

    //     // //Vehicle 5
    //     Vehicles.Add(new Vehicle(9876, 2016, "Hyundai", "Sonata"));

    //     //Trucks
    //     //Vehicle 6
    //     Vehicles.Add(new Truck(5670, 2020, "International", "LT625", true, 1, 18, "Car Carrier"));

    //     // //Vehicle 7
    //     Vehicles.Add(new Truck(4687, 2024, "FREIGHTLINER", "114sd", true, 1, 6, "Cement Mixer"));

    //     // //Vehicle 8
    //     Vehicles.Add(new Truck(1534, 2009, "WORKHORSE", "W62", true, 1, 4, "Cement Mixer"));

    //     VehicleStore.StoreData(Vehicles, true);

    // }


}