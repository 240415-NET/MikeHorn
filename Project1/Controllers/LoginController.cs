using Project1.Models;
using Project1.DataAccess;

namespace Project1.Controllers;


public class LoginController
{
    public static IUserDataManagement UserStore = new UserStorageJSON();
    public static string UserExists(string _UserName)
    {
        if(_UserName == "0") //they want to exit
        {
            return "Exit";
        }else if(ProcessUserMenuItems.UserExists(_UserName) == false) //username is not found
        {
            return "Absent";
        }else //username is found
        {
            return _UserName;
        }
    }

    public static string GetRole(string _UserName)
    {
        return UserStore.FindData(_UserName).UserRole;

    }
}