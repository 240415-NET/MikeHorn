namespace Project1.Models;

public interface IVehicleDataManagement
{
    //XXX Obsolete used for JSON
    // public VehiclesDTO RetrieveData(VehiclesDTO Vehicles);//DTO
    public VehiclesDTO RetrieveData();//DTO

    public  void StoreData(VehiclesDTO PassedListOfVehicles, bool refresAll);//DTO

    public void DeleteData(Guid Id, bool isCar);
    
    public Vehicle FindData(string valueToFind);


}