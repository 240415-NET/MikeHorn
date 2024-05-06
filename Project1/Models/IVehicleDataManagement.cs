namespace Project1.Models;

public interface IVehicleDataManagement
{
    public List<Vehicle> RetrieveData(List<Vehicle> Vehicles);
    public  void StoreData(List<Vehicle> PassedListOfVehicles, bool refresAll);
    
    public Vehicle FindData(string valueToFind);
    // public Vehicle FindData(string valueToFind, string valueType);
}