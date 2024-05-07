using Project1.Presentation;

namespace Project1;

class MainClass
{
    static void Main(string[] args)
    {
        // Console.Clear();

        MainMenuClass main = new MainMenuClass();
        bool Login;

        Login = LoginPresentationClass.StartLogin();

        if(Login = false)
        {
            return;
        }else
        {

            main.MainMenu();
        }
        
        // MainMenuClass.MainMenu();
    }
}
