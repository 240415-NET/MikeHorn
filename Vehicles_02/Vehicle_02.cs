namespace Vehicles_02;

class Vehicle
{
    //Fields
    public int PolicyId {get; set;}
    public int year {get; set;}
    public string make {get; set;}
    public string model {get; set;}
    public bool Active {get; set;}
    public int VehicleNumber {get; set;}

    //Methods
    public static bool Toggle_Active(bool Active_Deactive)
    {
        return !Active_Deactive;
    }

}