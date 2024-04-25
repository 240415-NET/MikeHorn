namespace Vehicles_02;

class Truck : Vehicle
{
    private int NumberWheels = 4;
    private string TruckType = "Box";

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
        List<string> AllowableTruckTypes = new List<string>{"Tractor Trailer", "Box", "Flatbed", "Dump", "Garbage", "Cement"};
        if(AllowableTruckTypes.Contains(TruckType))
        {
            this.TruckType = TruckType;
        }
        else
        {
            this.TruckType = "Box";
        }
        
    }

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

    public override string ToString()
    {
        string VehicleStatusValue = "Active";
        if(!VehicleStatus)
        {
            VehicleStatusValue = "Inactive";
        }
        return $"Policy: {PolicyId} Year: {year} Make: {make} Model: {model} Status: {VehicleStatusValue} Vehicle Number: {VehicleNumber} Number of Wheels: {NumberWheels} Truck Type: {TruckType}";
    }
}