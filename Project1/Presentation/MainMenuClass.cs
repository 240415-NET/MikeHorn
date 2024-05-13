

namespace Project1.Presentation;
public class MainMenuClass
{
    private static bool Continue = true;
    string[] strMainMenuItems;

    public void MainMenu(string _UserRole)
    {
        if(_UserRole == "Agent") //an agent cannot manage users
        {
            strMainMenuItems = [ "exit", "manage vehicles" ];
        }else //only and Admin or Supervisor can manage users
        {
            strMainMenuItems = [ "exit", "manage vehicles", "manage users" ];
        }
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strMainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strMainMenuItems))
            {
                ProcessMainMenu(Convert.ToInt16(strMenuSelection), _UserRole);
            }
        }while (Continue);

    }


    public void ProcessMainMenu(int intMenuSelection, string _UserRole)
    {
        Console.WriteLine(" \n");

        try
        {
            switch (intMenuSelection)
            {
                case 0: //exit
                    Continue = false;
                    break;
                case 1: //manage vehicles

                    VehicleMenuClass.VehicleMenu(_UserRole);

                    break;

                case 2: //manage users
                    UserMenuClass.UserMenu();
                    break;

            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }

    
}
