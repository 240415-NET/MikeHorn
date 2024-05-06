using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;




class ProcessUserMenuItems
{
    public static IUserStorage UserStore = new UserStorageJSON();
    public static List<User> GetUsers(List<User> Users)
    {
        Users = UserStore.RetrieveUsers(Users);
        return Users;
    }

    public static void SetUsers(List<User> Users, string UserName, string UserRole)
    {
        Users.Add(new User(UserName, UserRole));

        UserStore.StoreUsers(Users, true);
    }

    public static void RemoveUser(List<User> Users, int intIndex)
    {
        Users.RemoveAt(intIndex);

    }

    //Obsolete
    public static void BulkUsers(List<User> Users)
    {
        //User 0
        Users.Add(new User("MiHorn", "Admin"));

        //User 1
        Users.Add(new User("CKnox", "Supervisor"));

        //User 2
        Users.Add(new User("RWheatley", "Agent"));

        //User 3
        Users.Add(new User("OFlores", "Omar"));


    }

    public static bool UserExists(string UserName)
    {
        if(UserStore.FindUser(UserName) != null)
        {
            return true;
        }

        return false;
    }
}