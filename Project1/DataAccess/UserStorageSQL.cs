using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccess;

public class UserStorageSQL : IUserDataManagement
{
    //path to file containing the connections string
    public static string sqlConnectionFilePath = @"C:\Users\A219146\OneDrive - Government Employees Insurance Company\NET Bootcamp\SQL\Project1\Project1Connection.txt";
    //Get actual connection string
    public static string connectionString = File.ReadAllText(sqlConnectionFilePath); 

    public List<User> RetrieveData()
    {
        List<User> Users = new();

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
    

    public void StoreData(User PassedUser, bool refresAll)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string userQuery =
        @"INSERT INTO Users (UserId, UserName, UserRole)
        VALUES
        (@UserId, @UserName, @UserRole);";

        using SqlCommand queryResults = new SqlCommand(userQuery, connection);

        queryResults.Parameters.AddWithValue("@UserId", Convert.ToString(PassedUser.UserId));
        queryResults.Parameters.AddWithValue("@UserName", PassedUser.UserName);
        queryResults.Parameters.AddWithValue("@UserRole", PassedUser.UserRole);

        queryResults.ExecuteNonQuery();

        connection.Close();

    }
    
    public void DeleteData(Guid Id)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string userQuery =
        @"DELETE FROM Users WHERE UserId = @UserId;";

        using SqlCommand queryResults = new SqlCommand(userQuery, connection);

        queryResults.Parameters.AddWithValue("@UserId", Convert.ToString(Id));


        queryResults.ExecuteNonQuery();

        connection.Close();
    }

    public List<User> FindUser(string userName)
    {
        List<User> Users = new();

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string userQuery = @"SELECT UserId, UserName, UserRole FROM Users WHERE UserName = @userName;";

        using SqlCommand queryResults = new SqlCommand(userQuery, connection);
        queryResults.Parameters.AddWithValue("@userName", userName);

        using SqlDataReader reader = queryResults.ExecuteReader();

        while (reader.Read())
        {
            Users.Add(new User(Guid.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2)));
        }

        connection.Close();


        return Users;
    }
}