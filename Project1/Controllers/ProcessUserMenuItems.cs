using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;


public class ProcessUserMenuItems
{
    
    // public static IUserDataManagement UserStore = new UserStorageJSON();
    public static IUserDataManagement UserStore = new UserStorageSQL();
    public static List<User> GetUsers(List<User> Users)
    {
        // Users = UserStore.RetrieveData(Users);
        Users = UserStore.RetrieveData(Users);
        return Users;
    }

    public static void SetUsers(List<User> Users, string UserName, string UserRole)
    {
        Users.Clear();

        Users.Add(new User(UserName, UserRole));

        UserStore.StoreData(Users, true);
    }

    //TODO fix this
    public static void RemoveUser(List<User> Users, int intIndex)
    {
        //for JSON
        // Users.RemoveAt(intIndex);

        // UserStore.StoreData(Users, true);

        //for SQL
        UserStore.DeleteData(Users[intIndex].UserId);

    }


    public static bool UserExists(string UserName)
    {
        List<User> Users = new();

        List<User> subsetUsers = ProcessUserMenuItems.RetrieveUser(Users, UserName);

        if(subsetUsers == null || subsetUsers.Count == 0) //user not found
        {
            return false;
        }else //user(s) found
        {
            return true;
        }

    }

    public static List<User> RetrieveUser(List<User> Users, string userName)
    {
        return UserStore.FindUser(Users, userName);
    }

}