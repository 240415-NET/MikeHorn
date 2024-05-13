using Project1.Models;
using System.Text.Json;

namespace Project1.DataAccess;

public class VehicleStorageJSON : IVehicleDataManagement
{
    public static readonly string FilePath = ".//DataAccess//VehiclesFile.json";

    public VehiclesDTO RetrieveData(VehiclesDTO Vehicles)//DTO
    {

        if (File.Exists(FilePath)) //file exists and will read the file and then add the new Vehicle
        {
            string VehiclesJSONFilePath = File.ReadAllText(FilePath);

            Vehicles = JsonSerializer.Deserialize<VehiclesDTO>(VehiclesJSONFilePath);

            return Vehicles;

        }
        else //file doesn't exist and will be created and Vehicle will be added
        {

            return Vehicles;
        }

    }
    public List<Vehicle> RetrieveData(List<Vehicle> Vehicles)//Vehicle
    {

        if (File.Exists(FilePath)) //file exists and will read the file and then add the new Vehicle
        {
            string VehiclesJSONFilePath = File.ReadAllText(FilePath);

            Vehicles = JsonSerializer.Deserialize<List<Vehicle>>(VehiclesJSONFilePath);

            return Vehicles;

        }
        else //file doesn't exist and will be created and Vehicle will be added
        {

            return Vehicles;

        }

    }

    public void StoreData(VehiclesDTO PassedListOfVehicles, bool refreshAll)//DTO 
    {
        VehiclesDTO ListOfVehicles = new();

        if (File.Exists(FilePath)) //file exists and will read the file and then add the new Vehicle
        {
            if (refreshAll)//if need to just add full list due to a delete or change
            {
                string refreshListOfVehicles = JsonSerializer.Serialize(PassedListOfVehicles);
                File.WriteAllText(FilePath, refreshListOfVehicles);

            }
            else
            { //if need to add to what was existing
                string ExistingVehiclesJSONFilePath = File.ReadAllText(FilePath);

                ListOfVehicles = JsonSerializer.Deserialize<VehiclesDTO>(ExistingVehiclesJSONFilePath);

                ListOfVehicles.Cars.AddRange(PassedListOfVehicles.Cars);
                ListOfVehicles.Trucks.AddRange(PassedListOfVehicles.Trucks);

                string ExistingListOfVehicles = JsonSerializer.Serialize(ListOfVehicles);

                File.WriteAllText(FilePath, ExistingListOfVehicles);
            }

        }
        else //file doesn't exist and will be created and Vehicle will be added
        {

            string NewListOfVehicles = JsonSerializer.Serialize(PassedListOfVehicles);

            File.WriteAllText(FilePath, NewListOfVehicles);

        }
    }

    public void StoreData(List<Vehicle> PassedListOfVehicles, bool refreshAll)//Vehicle
    {
        List<Vehicle> ListOfVehicles = new List<Vehicle>();

        if (File.Exists(FilePath)) //file exists and will read the file and then add the new Vehicle
        {
            if (refreshAll)//if need to just add full list due to a delete or change
            {
                string refreshListOfVehicles = JsonSerializer.Serialize(PassedListOfVehicles);
                File.WriteAllText(FilePath, refreshListOfVehicles);

            }
            else
            { //if need to add to what was existing
                string ExistingVehiclesJSONFilePath = File.ReadAllText(FilePath);

                ListOfVehicles = JsonSerializer.Deserialize<List<Vehicle>>(ExistingVehiclesJSONFilePath);

                ListOfVehicles.AddRange(PassedListOfVehicles);

                string ExistingListOfVehicles = JsonSerializer.Serialize(ListOfVehicles);

                File.WriteAllText(FilePath, ExistingListOfVehicles);
            }

        }
        else //file doesn't exist and will be created and Vehicle will be added
        {
            ListOfVehicles.AddRange(PassedListOfVehicles);

            string NewListOfVehicles = JsonSerializer.Serialize(ListOfVehicles);

            File.WriteAllText(FilePath, NewListOfVehicles);

        }
    }

    public Vehicle FindData(string VehiclenameToFind)
    {
        //Vehicle object to store a Vehicle if they are found or NULL if they are not
        Vehicle foundVehicle = new Vehicle();

        try
        {

            //First, read the string back from our .json file
            string existingVehiclesJson = File.ReadAllText(FilePath);

            //Then, we need to serialize the string back into a List of Vehicle objects
            List<Vehicle> existingVehiclesList = JsonSerializer.Deserialize<List<Vehicle>>(existingVehiclesJson);


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return foundVehicle;

    }


}