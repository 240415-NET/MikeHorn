using Project1.Controllers;
using Project1.Presentation;
using Project1.Models;

namespace Project1;

class MainClass
{
    static void Main(string[] args)
    {
        // Console.Clear();

        MainMenuClass main = new MainMenuClass();

        List<User> Users = LoginPresentationClass.StartLogin();
        // string Login;
        // string UserRole;

        // Login = LoginPresentationClass.StartLogin();

        if(Users == null) //User not found
        {
            return;
        }else //user found
        {
            // UserRole = LoginController.GetRole(Login);
            main.MainMenu(Users[0].UserRole);
        }
        
        // MainMenuClass.MainMenu();
    }
}
