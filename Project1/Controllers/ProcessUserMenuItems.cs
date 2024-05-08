using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;


class ProcessUserMenuItems
{
    public static IUserDataManagement UserStore = new UserStorageJSON();
    public static List<User> GetUsers(List<User> Users)
    {
        Users = UserStore.RetrieveData(Users);
        return Users;
    }

    public static void SetUsers(List<User> Users, string UserName, string UserRole)
    {
        Users.Add(new User(UserName, UserRole));

        UserStore.StoreData(Users, true);
    }

    public static void RemoveUser(List<User> Users, int intIndex)
    {
        Users.RemoveAt(intIndex);

        UserStore.StoreData(Users, true);

    }

       public static bool UserExists(string UserName)
    {
        if(UserStore.FindData(UserName) != null)
        {
            return true;
        }

        return false;
    }

    public static List<User> FindUser(List<User> Users, string userName)
    {
        try
        {
        // LINQ Query
            var subsetUsers = from theUser in Users
                                where theUser.UserName == userName
                                select theUser;

            List<User> Results = subsetUsers.ToList();

            return Results;
        }
        catch (Exception excp)
        {
            Console.WriteLine("Error in ProcessUserMenuItems.FindUser");
            Console.WriteLine($"Error detected {excp.Message}");
            return null;

        }
    }
}