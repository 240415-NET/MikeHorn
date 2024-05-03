namespace Project1.Models;

public class Truck : Vehicle
{
    private int NumberWheels = 4;
    private string TruckType = "Flatbed Truck";

    //Constructors
    public Truck()
    {

    }

    public Truck(int PolicyId, int year, string make, string model, bool VehicleStatus, int VehicleNumber, int NumberWheels, string TruckType) 
    : base(PolicyId, year, make, model, VehicleStatus, VehicleNumber)
    {
        SetNumberWheels(NumberWheels);
        SetTruckType(TruckType);
    }

    //Getters and Setters
    //NumberWheels
    public int GetNumberWheels()
    {
        return this.NumberWheels;
    }

    public void SetNumberWheels(int NumberWheels)
    {
        switch (NumberWheels)
        {
            case < 4:
                this.NumberWheels = 4;
                break;
            case > 18:
                this.NumberWheels = 18;
                break;
            default:
                this.NumberWheels = NumberWheels;
                break;
        }
    }

     //TruckType
    public string GetTruckType()
    {
        return this.TruckType;
    }

    public void SetTruckType(string TruckType)
    {
        List<string> AllowableTruckTypes = new List<string>{"Car Carrier", "Cement Mixer", "Flatbed Truck", "Garbage Truck", "Refrigerated Truck", "Tow Truck - one axle", "Tow Truck- two axle"};
        if(AllowableTruckTypes.Contains(TruckType))
        {
            this.TruckType = TruckType;
        }
        else
        {
            this.TruckType = "Flatbed Truck";
        }
        
    }

    
    public override string ToString()
    {
        string VehicleStatusValue = "Active";
        if(!VehicleStatus)
        {
            VehicleStatusValue = "Inactive";
        }
        return $"Policy: {PolicyId}\tYear: {year}\tMake: {make}\t\tModel: {model}\tStatus: {VehicleStatusValue}\tVehicle Number: {VehicleNumber}\tNumber of Wheels: {NumberWheels}\tTruck Type: {TruckType}";
    }
}