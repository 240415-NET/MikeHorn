namespace Project11EF.API.Models;

public interface IVehicleStorageEF
{
    public Task<Vehicle> CreateVehicleInDBAsync(Vehicle newVehicleFromVehicleService);

    public Task<Truck> CreateTruckInDBAsync(Truck newTruckFromVehicleService);
}