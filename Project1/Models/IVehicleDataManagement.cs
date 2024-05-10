namespace Project1.Models;

public interface IVehicleDataManagement
{
    public List<Vehicle> RetrieveData(List<Vehicle> Vehicles);
    public VehiclesDTO RetrieveData(VehiclesDTO Vehicles);//DTO
    public  void StoreData(List<Vehicle> PassedListOfVehicles, bool refresAll);
    public  void StoreData(VehiclesDTO PassedListOfVehicles, bool refresAll);//DTO
    
    public Vehicle FindData(string valueToFind);
    // public Vehicle FindData(string valueToFind, string valueType);
}