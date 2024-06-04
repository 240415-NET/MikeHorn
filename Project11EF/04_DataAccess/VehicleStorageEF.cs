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

    public async Task<Vehicle> CreateVehicleInDBAsync(Vehicle newVehicleFromVehicleService)
    {
        vehicleContext.Vehicles.Add(newVehicleFromVehicleService);

        await vehicleContext.SaveChangesAsync();

        return newVehicleFromVehicleService;
    }

    public async Task<Truck> CreateTruckInDBAsync(Truck newTruckFromVehicleService)
    {
        vehicleContext.Trucks.Add(newTruckFromVehicleService);

        await vehicleContext.SaveChangesAsync();

        return newTruckFromVehicleService;
    }

}