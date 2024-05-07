using Project1.Models;
using Project1.Controllers;

namespace Project1.Presentation;
public class LoginPresentationClass
{
    public static bool StartLogin()
    {
        string strReturn;

        Console.WriteLine("Please enter your username to Login or 0 to exit");
        
        strReturn = LoginController.UserExists(Console.ReadLine());

        switch (strReturn)
        {
            case "Exit":
                return false;
            case "Absent":
                Console.WriteLine("Username is not found");
                return false;
            case "Found":
                return true;
            default:
                return false;
        }

    }
}