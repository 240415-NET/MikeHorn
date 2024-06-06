using Project11EF.API.Models;

namespace Project11EF.API.Services;

public class VehicleService : IVehicleService
{
    //Declaration for Dependency Injection
    private readonly IVehicleStorageEF vehicleStorageEFObject;

    public VehicleService(IVehicleStorageEF vehicleStorageEFObjectFromBuilder)
    {
        vehicleStorageEFObject = vehicleStorageEFObjectFromBuilder;
    }
    /** Create **************************************************************************/
    //Car
    public async Task<Vehicle> CreateNewVehicleAsync(Vehicle newVehicleFromController)
    {
        await vehicleStorageEFObject.CreateVehicleInDBAsync(newVehicleFromController);
        return newVehicleFromController;

    }

    //Truck
    public async Task<Truck> CreateNewTruckAsync(Truck newTruckFromController)
    {
        await vehicleStorageEFObject.CreateTruckInDBAsync(newTruckFromController);
        return newTruckFromController;

    }

    /** Get All **************************************************************************/
    //Cars
    public List<Vehicle> GetAllVehicles()
    {
        return vehicleStorageEFObject.GetAllVehicles();
    }
    //Trucks
    public List<Truck> GetAllTrucks()
    {
        return vehicleStorageEFObject.GetAllTrucks();
    }

    /** Get by VehicleId **************************************************************************/
    //Cars
    public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleIdToGetFromController)
    {
        return await vehicleStorageEFObject.GetVehicleByIdAsync(vehicleIdToGetFromController);
    }

    /** Update **************************************************************************/
    //Car
    public async Task<Vehicle?> UpdateVehicleAsync(Vehicle vehicleToUpdateFromController)
    {
        return await vehicleStorageEFObject.UpdateVehicleAsync(vehicleToUpdateFromController);
    }
}