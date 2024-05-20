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
        //Determine if user exists
        Users = ProcessUserMenuItems.RetrieveUser(strSent);

        if(Users.Count == 0) //Users not found
        {
            Console.WriteLine("User was not found");
            return null;
        }else
        {
            return Users;
        }


        //XXX Obsolete needed for JSON
        // Users = ProcessUserMenuItems.GetUsers(Users);

        // List<User> subsetUsers = ProcessUserMenuItems.RetrieveUser(Users, strSent);

        // if(subsetUsers == null || subsetUsers.Count == 0) //user not found
        // {
        //     Console.WriteLine("User was not found");
        //     return null;
        // }else //user(s) found
        // {
        //     return subsetUsers;
        // }

    }

   
}