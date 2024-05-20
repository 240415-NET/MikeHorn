namespace Project1.Models;


public class Vehicle
{
    //Fields
    public int PolicyId {get; set;}
    public int year {get; set;}
    public string make {get; set;}
    public string model {get; set;}
    public bool VehicleStatus {get; set;}
    public Guid VehicleId {get; set;}

    //Constructors
    public Vehicle()
    {

    }

    public Vehicle(int PolicyId, int year, string make, string model)
    {
        SetPolicyId(PolicyId);
        Setyear(year);
        Setmake(make);
        Setmodel(model);
        SetVehicleStatus(true);
        SetVehicleId();

    }

    public Vehicle(int PolicyId, int year, string make, string model, bool VehicleStatus) : this(PolicyId, year, make, model)
    {

        SetVehicleStatus(VehicleStatus);
        SetVehicleId();

    }

    public Vehicle(int PolicyId, int year, string make, string model, bool VehicleStatus, Guid VehicleId) : this(PolicyId, year, make, model,VehicleStatus)
    {
        this.VehicleId = VehicleId;

    }


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
    public Guid GetVehicleId()
    {
        return this.VehicleId;
    }

    public void SetVehicleId()
    {
        this.VehicleId = Guid.NewGuid();
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
        return $"Policy: {PolicyId}\tYear: {year}\tMake: {make}\t\tModel: {model}\tStatus: {VehicleStatusValue}\tVehicleId: {VehicleId}";
    }
    
}