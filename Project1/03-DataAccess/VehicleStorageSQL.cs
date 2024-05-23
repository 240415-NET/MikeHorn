using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccess;

public class VehicleStorageSQL : IVehicleDataManagement
{
    //path to file containing the connections string
    public static string sqlConnectionFilePath = @"C:\Users\A219146\OneDrive - Government Employees Insurance Company\NET Bootcamp\SQL\Project1\Project1Connection.txt";
    //Get actual connection string
    public static string connectionString = File.ReadAllText(sqlConnectionFilePath);
    //mark 09
    public VehiclesDTO RetrieveData()
    {
        VehiclesDTO Vehicles = new();
        List<Vehicle> CarsList = new();
        List<Truck> TrucksList = new();

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        //Retrieve Cars
        string CarsQuery = @"SELECT 
                                PolicyId
                                ,year
                                ,make
                                ,model
                                ,VehicleStatus
                                ,VehicleId
                             FROM Cars;";

        using SqlCommand queryResults = new SqlCommand(CarsQuery, connection);

        using SqlDataReader reader = queryResults.ExecuteReader();

        while (reader.Read())
        {   

            CarsList.Add(new Vehicle(
                                     reader.GetInt32(0) //PolicyId
                                    , reader.GetInt32(1) //year
                                    , reader.GetString(2) //make
                                    , reader.GetString(3) //model
                                    , reader.GetBoolean(4) //VehicleStatus
                                    ,Guid.Parse(reader.GetString(5)) //VehicleId
                                    )
                        );
        }

        reader.Close();

        //Retrieve Trucks
        String TrucksQuery =      @"SELECT 
                            PolicyId
                            ,year
                            ,make
                            ,model
                            ,VehicleStatus
                            ,VehicleId
                            ,NumberWheels
                            ,TruckType
                        FROM Trucks;";

        using SqlCommand queryResultsTrucks = new SqlCommand(TrucksQuery, connection);

        using SqlDataReader readerTrucks = queryResultsTrucks.ExecuteReader();

        while (readerTrucks.Read())
        {

            TrucksList.Add(new Truck(
                                     readerTrucks.GetInt32(0) //PolicyId
                                    , readerTrucks.GetInt32(1) //year
                                    , readerTrucks.GetString(2) //make
                                    , readerTrucks.GetString(3) //model
                                    , readerTrucks.GetBoolean(4) //VehicleStatus
                                    ,Guid.Parse(readerTrucks.GetString(5)) //VehicleId
                                    ,readerTrucks.GetInt32(6) //NumberWheels
                                    ,readerTrucks.GetString(7) //TruckType
                                    )
                        );
        }

        readerTrucks.Close();

        connection.Close();

        Vehicles.Cars = CarsList;
        Vehicles.Trucks = TrucksList;

        return Vehicles;
    }

    public void StoreData(VehiclesDTO PassedListOfVehicles, bool refresAll)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        
        


        connection.Open();

        //Store Cars
        if(PassedListOfVehicles.Cars.Count > 0) //Car passed
        {
            Vehicle Car = PassedListOfVehicles.Cars[0];
            string userQuery =
            @"INSERT INTO Cars (PolicyId ,year ,make ,model ,VehicleStatus ,VehicleId)
            VALUES
            (@PolicyId ,@year ,@make ,@model ,@VehicleStatus ,@VehicleId);";

            using SqlCommand queryResults = new SqlCommand(userQuery, connection);

            
            queryResults.Parameters.AddWithValue("@PolicyId", Car.PolicyId);
            queryResults.Parameters.AddWithValue("@year", Car.year);
            queryResults.Parameters.AddWithValue("@make", Car.make);
            queryResults.Parameters.AddWithValue("@model", Car.model);
            queryResults.Parameters.AddWithValue("@VehicleStatus", Car.VehicleStatus ? 1 : 0);
            queryResults.Parameters.AddWithValue("@VehicleId", Convert.ToString(Car.VehicleId));

            queryResults.ExecuteNonQuery();
        }else if(PassedListOfVehicles.Trucks.Count > 0)  //Truck passed
        {
            Truck Truck = PassedListOfVehicles.Trucks[0];
            string userQuery =
            @"INSERT INTO Trucks (PolicyId ,year ,make ,model ,VehicleStatus ,VehicleId ,NumberWheels ,TruckType)
            VALUES
            (@PolicyId ,@year ,@make ,@model ,@VehicleStatus ,@VehicleId ,@NumberWheels ,@TruckType);";

            using SqlCommand queryResults = new SqlCommand(userQuery, connection);

            
            queryResults.Parameters.AddWithValue("@PolicyId", Truck.PolicyId);
            queryResults.Parameters.AddWithValue("@year", Truck.year);
            queryResults.Parameters.AddWithValue("@make", Truck.make);
            queryResults.Parameters.AddWithValue("@model", Truck.model);
            queryResults.Parameters.AddWithValue("@VehicleStatus", Truck.VehicleStatus ? 1 : 0);
            queryResults.Parameters.AddWithValue("@VehicleId", Convert.ToString(Truck.VehicleId));
            queryResults.Parameters.AddWithValue("@NumberWheels", Truck.NumberWheels);
            queryResults.Parameters.AddWithValue("@TruckType", Truck.TruckType);

            queryResults.ExecuteNonQuery();
        }


        connection.Close();
    }

    public void DeleteData(Guid Id, bool isCar)
    {
        string vehicleQuery = "";
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        if(isCar) //delete a car
        {
            vehicleQuery = @"DELETE FROM Cars WHERE VehicleId = @VehicleId;";
        }else //delete a truck
        {
            vehicleQuery = @"DELETE FROM Trucks WHERE VehicleId = @VehicleId;";
        }

        using SqlCommand queryResults = new SqlCommand(vehicleQuery, connection);

        queryResults.Parameters.AddWithValue("@VehicleId", Convert.ToString(Id));


        queryResults.ExecuteNonQuery();

        connection.Close();
    }

    public void ToggleVehicleStatus(Guid Id, bool isCar)
    {
        string vehicleQuery = "";
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        if(isCar) //a car
        {
            vehicleQuery = @"UPDATE Cars
                            SET VehicleStatus = ~VehicleStatus
                            WHERE VehicleId = @VehicleId;";
        }else //a truck
        {
            vehicleQuery = @"UPDATE Trucks
                            SET VehicleStatus = ~VehicleStatus
                            WHERE VehicleId = @VehicleId;";
        }

        using SqlCommand queryResults = new SqlCommand(vehicleQuery, connection);

        queryResults.Parameters.AddWithValue("@VehicleId", Convert.ToString(Id));


        queryResults.ExecuteNonQuery();

        connection.Close();
    }
    public Vehicle FindData(string valueToFind)
    {
        throw new NotImplementedException();
    }

    
}