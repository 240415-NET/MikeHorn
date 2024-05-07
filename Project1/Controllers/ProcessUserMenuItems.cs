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
}