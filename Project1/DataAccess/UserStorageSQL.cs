using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccess;

public class UserStorageSQL : IUserDataManagement
{
    //path to file containing the connections string
    public static string sqlConnectionFilePath = @"C:\Users\A219146\OneDrive - Government Employees Insurance Company\NET Bootcamp\SQL\Project1\Project1Connection.txt";
    //Get actual connection string
    public static string connectionString = File.ReadAllText(sqlConnectionFilePath); 

    public List<User> RetrieveData(List<User> Users)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string userQuery = "SELECT UserId, UserName, UserRole FROM Users;";

        using SqlCommand queryResults = new SqlCommand(userQuery, connection);

        using SqlDataReader reader = queryResults.ExecuteReader();

        while (reader.Read())
        {
            Users.Add(new User(Guid.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2)));
        }

        connection.Close();

        return Users;
    }
    
   
    public void StoreData(List<User> PassedListOfUsers, bool refresAll)
    {

    }
    

    public List<User> FindUser(List<User> Users, string userName)
    {
        return null;
    }
}