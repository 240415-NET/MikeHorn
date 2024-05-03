using Project1.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace Project1.DataAccess;

public class UserStorage
{
    public static readonly string FilePath = ".//DataAccess//UsersFile.json";

    public static List<User> RetrieveUsers()
    {
        List<User>? ListOfUsers = new List<User>();

        if(File.Exists(FilePath)) //file exists and will read the file and then add the new user
        {
            string UsersJSONFilePath = File.ReadAllText(FilePath);

            ListOfUsers = JsonSerializer.Deserialize<List<User>>(UsersJSONFilePath);

            return ListOfUsers;

        }else //file doesn't exist and will be created and user will be added
        {

            return ListOfUsers;
        }

    }
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

    //Obsolete
    public static void StoreUsers(List<User> PassedListOfUsers)
    {
        // string FilePath = ".//DataAccess//UsersFile.json";
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

    public static User FindUser(string usernameToFind)
    {
        //User object to store a user if they are found or NULL if they are not
        User foundUser = new User();

        try{

            //First, read the string back from our .json file
            string existingUsersJson = File.ReadAllText(FilePath);

            //Then, we need to serialize the string back into a List of User objects
            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);
            
            foundUser = existingUsersList.FirstOrDefault(user => user.UserName == usernameToFind);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return foundUser;

    }

    

}