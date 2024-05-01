namespace Project1.Presentation;
using Project1.Models;
public class AddVehicleClass
{
    public static void AddVehicle(List<Vehicle> Vehicles)
    {
        Vehicles.Add(new Vehicle());

        Console.WriteLine("Please enter the Policy Id");
        Vehicles[Vehicles.Count - 1].SetPolicyId(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Year");
        Vehicles[Vehicles.Count - 1].Setyear(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine("Please enter the Vehicle's Make");
        Vehicles[Vehicles.Count - 1].Setmake(Console.ReadLine());

        Console.WriteLine("Please enter the Vehicle's Model");
        Vehicles[Vehicles.Count - 1].Setmodel(Console.ReadLine());

        Vehicles[Vehicles.Count - 1].SetVehicleStatus(true);

        Vehicles[Vehicles.Count - 1].SetVehicleNumber(Vehicles.Count);
    }
}