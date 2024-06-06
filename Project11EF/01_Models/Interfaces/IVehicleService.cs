namespace Project11EF.API.Models;

public interface IVehicleService
{
    public Task<Vehicle> CreateNewVehicleAsync(Vehicle newVehicleFromController);
    public Task<Truck> CreateNewTruckAsync(Truck newTruckFromController);

    public List<Vehicle> GetAllVehicles();
    public List<Truck> GetAllTrucks();
    public Task<Vehicle?> GetVehicleByIdAsync(Guid vehicleIdToGetFromController);
    public Task<Vehicle> UpdateVehicleAsync(Vehicle vehicleToUpdateFromController);
}