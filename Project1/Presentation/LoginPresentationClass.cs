using Project1.Controllers;
using Project1.Models;

namespace Project1.Presentation;
public class LoginPresentationClass
{
    public static List<User> StartLogin()
    {
        List<User> Users = new();
        string strSent;

        Console.WriteLine("Please enter your username to Login or 0 to exit");
        strSent = Console.ReadLine();

        List<User> subsetUsers = ProcessUserMenuItems.RetrieveUser(Users, strSent);

        // return subsetUsers;

        if(subsetUsers == null || subsetUsers.Count == 0) //user not found
        {
            return null;
        }else //user(s) found
        {
            return subsetUsers;
        }
        
        // strReturn = LoginController.UserExists(strSent);

        // switch (strReturn)
        // {
        //     case "Exit":
        //         return "Exit";
        //     case "Absent":
        //         Console.WriteLine("Username is not found");
        //         return "Exit";
        //     default:
        //         return strReturn;
            
        // }

    }

    // public static string StartLogin()
    // {
    //     string strReturn;
    //     string strSent;

    //     Console.WriteLine("Please enter your username to Login or 0 to exit");
    //     strSent = Console.ReadLine();
        
    //     strReturn = LoginController.UserExists(strSent);

    //     switch (strReturn)
    //     {
    //         case "Exit":
    //             return "Exit";
    //         case "Absent":
    //             Console.WriteLine("Username is not found");
    //             return "Exit";
    //         default:
    //             return strReturn;
            
    //     }

    // }
}