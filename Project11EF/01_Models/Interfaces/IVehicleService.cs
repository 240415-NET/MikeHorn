namespace Project11EF.API.Models;

public interface IVehicleService
{
    public Task<Vehicle> CreateNewVehicleAsync(Vehicle newVehicleFromController);
    public Task<Truck> CreateNewTruckAsync(Truck newTruckFromController);
}