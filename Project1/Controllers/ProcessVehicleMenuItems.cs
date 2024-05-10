using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;

class ProcessVehicleMenuItems
{
    public static IVehicleDataManagement VehicleStore = new VehicleStorageJSON();
    public static VehiclesDTO VehiclesObject = new();
    public static List<Vehicle> VehiclesList = new();
    public static List<Truck> TrucksList = new();

    public static VehiclesDTO GetVehicles(VehiclesDTO Vehicles)//DTO
    {
        Vehicles = VehicleStore.RetrieveData(Vehicles);
        return Vehicles;
    }

    public static List<Vehicle> GetVehicles(List<Vehicle> Vehicles)
    {
        Vehicles = VehicleStore.RetrieveData(Vehicles);
        return Vehicles;
    }

    public static void SetVehicles(VehiclesDTO Vehicles)
    {

        VehicleStore.StoreData(Vehicles, false);
    }
    public static void SetVehicles(List<Vehicle> Vehicles)
    {

        VehicleStore.StoreData(Vehicles, false);
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

     public static void AddVehicle(List<string> Answers)
    {
        // List<Vehicle> addedVehicle = new();

        VehiclesList.Add(new Vehicle());

        VehiclesList[0].SetPolicyId(Convert.ToInt16(Answers[0]));

        VehiclesList[0].Setyear(Convert.ToInt16(Answers[1]));

        VehiclesList[0].Setmake(Answers[2]);

        VehiclesList[0].Setmodel(Answers[3]);

        VehiclesList[0].SetVehicleStatus(true);

        VehiclesList[0].SetVehicleId();

        VehiclesObject.Cars = VehiclesList;
        VehiclesObject.Trucks = TrucksList;

        ProcessVehicleMenuItems.SetVehicles(VehiclesObject);
    }

    public static void AddTruck(List<string> Answers)
    {
        // List<Truck> addedTruck = new();
        TrucksList.Add(new Truck());

        TrucksList[0].SetPolicyId(Convert.ToInt16(Answers[0]));

        TrucksList[0].Setyear(Convert.ToInt16(Answers[1]));

        TrucksList[0].Setmake(Answers[2]);

        TrucksList[0].Setmodel(Answers[3]);

        TrucksList[0].SetNumberWheels(Convert.ToInt16(Answers[4]));

        TrucksList[0].SetTruckType(Answers[5]);

        TrucksList[0].SetVehicleStatus(true);

        TrucksList[0].SetVehicleId();

        VehiclesObject.Cars = VehiclesList;
        VehiclesObject.Trucks = TrucksList;

        ProcessVehicleMenuItems.SetVehicles(VehiclesObject);
    }

    //Obsolete
    // public static void BulkVehicles()
    // {
    //     VehiclesDTO VehiclesObject = new();
    //     List<Vehicle> VehiclesList = new();
    //     List<Truck> TrucksList = new();
    //     //Full Constructor
    //     //vehicle 0
    //     VehiclesList.Add(new Vehicle(1234, 2018, "Ford", "F150", true));

    //     //vehicle 1
    //     VehiclesList.Add(new Vehicle(1234, 2015, "Honda", "Accord", true));

    //     //vehicle 2
    //     VehiclesList.Add(new Vehicle(1234, 2010, "Volkswagon", "Jetta", true));

    //     //vehicle 3
    //     VehiclesList.Add(new Vehicle(5678, 2020, "Honda", "Civic", true));

    //     //Partial Constructor
    //     //Vehicle 4
    //     VehiclesList.Add(new Vehicle(5678, 2014, "Acura", "ILX"));

    //     // //Vehicle 5
    //     VehiclesList.Add(new Vehicle(9876, 2016, "Hyundai", "Sonata"));

    //     //Trucks
    //     //Vehicle 6
    //     TrucksList.Add(new Truck(5670, 2020, "International", "LT625", true, 18, "Car Carrier"));

    //     // //Vehicle 7
    //     TrucksList.Add(new Truck(4687, 2024, "FREIGHTLINER", "114sd", true, 6, "Cement Mixer"));

    //     // //Vehicle 8
    //     TrucksList.Add(new Truck(1534, 2009, "WORKHORSE", "W62", true, 4, "Cement Mixer"));

    //     VehiclesObject.Cars = VehiclesList;
    //     VehiclesObject.Trucks = TrucksList;

    //     VehicleStore.StoreData(VehiclesObject, true);

    // }


}