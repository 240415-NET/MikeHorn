namespace Vehicles_02;

class Vehicle
{
    //Fields
    private int PolicyId = 0;
    private int year = 1900;
    private string make = "";
    private string model = "";
    private bool VehicleStatus = true; //true = active, false = inactive
    private int VehicleNumber = 1;

    //Getters and Setters
    //Policy Id
    public int GetPolicyId()
    {
        return this.PolicyId;
    }

    public void SetPolicyId(int PolicyId)
    {
        this.PolicyId = PolicyId;
    }

    //year
    public int Getyear()
    {
        return this.year;
    }

    public void Setyear(int year)
    {
        switch (year)
        {
            case <= 1900:
                this.year = 1900;
                break;
            case > 2025:
                this.year = 2025;
                break;
            default:
                this.year = year;
                break;
        }
        this.year = year;
    }

    //make
    public string Getmake()
    {
        return this.make;
    }

    public void Setmake(string make)
    {
        this.make = make.Trim();
    }

    //model
    public string Getmodel()
    {
        return this.model;
    }

    public void Setmodel(string model)
    {
        this.model = model.Trim();
    }

    //VehicleStatus
    public bool GetVehicleStatus()
    {
        return this.VehicleStatus;
    }

    public void SetVehicleStatus(bool VehicleStatus)
    {
        this.VehicleStatus = VehicleStatus;
    }

    //VehicleNumber
    public int GetVehicleNumber()
    {
        return this.VehicleNumber;
    }

    public void SetVehicleNumber(int VehicleNumber)
    {
        this.VehicleNumber = VehicleNumber;
    }

    //Constructors
    public Vehicle(int PolicyId, int year, string make, string model, bool VehicleStatus, int VehicleNumber)
    {
        SetPolicyId(PolicyId);
        Setyear(year);
        Setmake(make);
        Setmodel(model);
        SetVehicleStatus(VehicleStatus);
        SetVehicleNumber(VehicleNumber);

    }

    public Vehicle()
    {

    }

    //Methods
    public static bool Toggle_VehicleStatus(bool VehicleStatus)
    {
        return !VehicleStatus;
    }

    public override string ToString()
    {
        string VehicleStatusValue = "Active";
        if(!VehicleStatus)
        {
            VehicleStatusValue = "Inactive";
        }
        return $"Policy: {PolicyId} Year: {year} Make: {make} Model: {model} Status: {VehicleStatusValue} Vehicle Number: {VehicleNumber} ";
    }
}