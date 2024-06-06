namespace Project11EF.API.Models;

public interface IVehicleStorageEF
{
    public Task<Vehicle> CreateVehicleInDBAsync(Vehicle newVehicleFromVehicleService);

    public Task<Truck> CreateTruckInDBAsync(Truck newTruckFromVehicleService);

    public List<Vehicle> GetAllVehicles();
    public List<Truck> GetAllTrucks();
    public Task<Vehicle?> GetVehicleByIdAsync(Guid vehicleIdToGetFromController);
    public Task<Vehicle?> UpdateVehicleAsync(Vehicle vehicleToUpdateFromVehicleService);
}