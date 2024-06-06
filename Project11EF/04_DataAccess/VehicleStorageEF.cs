using Microsoft.EntityFrameworkCore;
using Project11EF.API.Models;

namespace Project11EF.API.Data;

public class VehicleStorageEF : IVehicleStorageEF
{
    private readonly Project11EFContext vehicleContext;

    public VehicleStorageEF(Project11EFContext vehicleContextFromBuilder)
    {
        vehicleContext = vehicleContextFromBuilder;
    }

    /** Create **************************************************************************/
    //Car
    public async Task<Vehicle> CreateVehicleInDBAsync(Vehicle newVehicleFromVehicleService)
    {
        vehicleContext.Vehicles.Add(newVehicleFromVehicleService);

        await vehicleContext.SaveChangesAsync();

        return newVehicleFromVehicleService;
    }
    //Truck
    public async Task<Truck> CreateTruckInDBAsync(Truck newTruckFromVehicleService)
    {
        vehicleContext.Trucks.Add(newTruckFromVehicleService);

        await vehicleContext.SaveChangesAsync();

        return newTruckFromVehicleService;
    }

    /** Get All **************************************************************************/
    //Cars
    public List<Vehicle> GetAllVehicles()
    {
        return vehicleContext.Vehicles.OfType<Vehicle>().Where(v => v.GetType() == typeof(Vehicle)).ToList();
    }

    //Trucks
    public List<Truck> GetAllTrucks()
    {
        return vehicleContext.Trucks.ToList();
    }

    /** Get by VehicleId **************************************************************************/
    //Cars
    public async Task<Vehicle?> GetVehicleByIdAsync(Guid vehicleIdToGetFromController)
    {
        Vehicle? foundVehicle = await vehicleContext.Vehicles.SingleOrDefaultAsync(v => v.VehicleId == vehicleIdToGetFromController);
        return foundVehicle;
    }

    /** Update **************************************************************************/
    //Car
    public async Task<Vehicle?> UpdateVehicleAsync(Vehicle vehicleToUpdateFromVehicleService)
    {
        vehicleContext.Update(vehicleToUpdateFromVehicleService);
        await vehicleContext.SaveChangesAsync();
        return vehicleToUpdateFromVehicleService;

    }
}