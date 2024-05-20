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


        if(Users == null) //User not found
        {
            return;
        }else //user found
        {
            Console.WriteLine($"user role is {Users[0].UserRole}");
            main.MainMenu(Users[0].UserRole);
        }
        
    }
}
