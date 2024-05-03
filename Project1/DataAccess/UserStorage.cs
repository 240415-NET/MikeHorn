using Project1.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace Project1.DataAccess;

public class UserStorage
{
    public static void StoreUser(User _User)
    {
        string FilePath = ".//DataAccess//UsersFile.json";
        List<User> ListOfUsers = new List<User>();

        if(File.Exists(FilePath)) //file exists and will read the file and then add the new user
        {
            string ExistingUsersJSON = File.ReadAllText(FilePath);

            ListOfUsers = JsonSerializer.Deserialize<List<User>>(ExistingUsersJSON);

            ListOfUsers.Add(_User);

            string ExistingListOfUsers = JsonSerializer.Serialize(ListOfUsers);

            File.WriteAllText(FilePath, ExistingListOfUsers);

        }else if(!File.Exists(FilePath)) //file doesn't exist and will be created and user will be added
        {
            ListOfUsers.Add(_User);

            string NewListOfUsers = JsonSerializer.Serialize(ListOfUsers);

            File.WriteAllText(FilePath, NewListOfUsers);

        }
    }

    public static void StoreUsers(List<User> PassedListOfUsers)
    {
        string FilePath = ".//DataAccess//UsersFile.json";
        List<User> ListOfUsers = new List<User>();

        if(File.Exists(FilePath)) //file exists and will read the file and then add the new user
        {
            string ExistingUsersJSON = File.ReadAllText(FilePath);

            ListOfUsers = JsonSerializer.Deserialize<List<User>>(ExistingUsersJSON);

            // ListOfUsers.Add(_User);
            ListOfUsers.AddRange(PassedListOfUsers);

            string ExistingListOfUsers = JsonSerializer.Serialize(ListOfUsers);

            File.WriteAllText(FilePath, ExistingListOfUsers);

        }else if(!File.Exists(FilePath)) //file doesn't exist and will be created and user will be added
        {
            // ListOfUsers.Add(_User);
            ListOfUsers.AddRange(PassedListOfUsers);

            string NewListOfUsers = JsonSerializer.Serialize(ListOfUsers);

            File.WriteAllText(FilePath, NewListOfUsers);

        }
    }

public static bool UserExists(string UserName)
{
    return false;
}

}