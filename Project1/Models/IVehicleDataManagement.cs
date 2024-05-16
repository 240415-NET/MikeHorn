namespace Project1.Models;

public interface IVehicleDataManagement
{
    public VehiclesDTO RetrieveData(VehiclesDTO Vehicles);//DTO

    public  void StoreData(VehiclesDTO PassedListOfVehicles, bool refresAll);//DTO
    
    public Vehicle FindData(string valueToFind);

}