using Project1.Controllers;
using Project1.Presentation;

namespace Project1;

class MainClass
{
    static void Main(string[] args)
    {
        // Console.Clear();

        MainMenuClass main = new MainMenuClass();
        string Login;
        string UserRole;

        Login = LoginPresentationClass.StartLogin();

        if(Login == "Exit")
        {
            return;
        }else
        {
            UserRole = LoginController.GetRole(Login);
            main.MainMenu(UserRole);
        }
        
        // MainMenuClass.MainMenu();
    }
}
