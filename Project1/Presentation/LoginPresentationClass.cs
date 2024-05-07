using Project1.Models;
using Project1.Controllers;

namespace Project1.Presentation;
public class LoginPresentationClass
{
    public static string StartLogin()
    {
        string strReturn;
        string strSent;

        Console.WriteLine("Please enter your username to Login or 0 to exit");
        strSent = Console.ReadLine();
        
        strReturn = LoginController.UserExists(strSent);

        switch (strReturn)
        {
            case "Exit":
                return "Exit";
            case "Absent":
                Console.WriteLine("Username is not found");
                return "Exit";
            default:
                return strReturn;
            
        }

    }
}