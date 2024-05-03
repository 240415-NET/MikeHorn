
using Project1.Models;
using Project1.Controllers;
using Project1.DataAccess;
using Project1;
using System.Net;

namespace Project1.Presentation;
public class UserMenuClass
{
    public static List<User> Users = new List<User>();
    private static bool Continue = true;

    public static void UserMenu()
    {
        string[] strMainMenuItems = { "exit", "list users", "enter user", "remove a user", "enter bulk users" };
        
        string? strMenuSelection;
        
        do
        {
            Console.WriteLine("Please enter the number of your selection:\n");
            MenuClass.PrintMenu(strMainMenuItems);
            strMenuSelection = Console.ReadLine();
            if(MenuClass.ValidateMenuInput(strMenuSelection, strMainMenuItems))
            {
                ProcessUserMenu(Convert.ToInt16(strMenuSelection));
            }
        }while (Continue);

    }

    public static void ProcessUserMenu(int intMenuSelection)
    {
        ProcessMainMenuItems ProcessMenu = new();
        Console.WriteLine(" \n");

        try
        {
            switch (intMenuSelection)
            {
                case 0: //exit
                    Continue = false;
                    break;
                case 1: //list users

                    //Retrieve Users from Data Store and put into Users List
                    Users = UserStorage.RetrieveUsers();

                    if(Users != null)
                    {
                        foreach(User u in Users)
                        {
                            Console.WriteLine("Index = " + Users.IndexOf(u) + " " + u);
                        }
                    }else
                    {
                        Console.WriteLine("No users found");
                    }

                    Console.WriteLine(" \n");
                    break;
                case 2: //enter user

                    AddUser(Users);

                    UserStorage.StoreUser(Users[Users.Count -1]);
                    // UserStorage.StoreUsers(Users);

                    Console.WriteLine("User has now been added \n");

                    break;
                case 3: //remove a user
                    Console.WriteLine("Please enter the User's Index Number to remove");
                    ProcessUserMenuItems.RemoveUser(Users, Convert.ToInt16(Console.ReadLine()));

                    Console.WriteLine("User has now been removed \n");

                    break;
                //Obsolete
                case 4: //enter bulk users
                    ProcessUserMenuItems.BulkUsers(Users);

                    UserStorage.StoreUsers(Users);

                    Console.WriteLine("Bulk users have been added \n");

                    break;
            }
        }
        catch (Exception excp)
        {
            Console.WriteLine($"Error detected {excp.Message}");

        }
    }

    public static void AddUser(List<User> Users)
    {
        string UserName = "";
        string UserRole = "";
        bool ValidInput = true;

        do
        {
            Console.WriteLine("Please enter the user name");
            UserName = Console.ReadLine()?? "";

            UserName = UserName.Trim();

            if(String.IsNullOrEmpty(UserName))
            {
                Console.WriteLine("user name cannot be blank, please try again");
                ValidInput = false;
            }else if(ProcessUserMenuItems.UserExists(UserName))
            {
                Console.WriteLine("this user name already exists, please try another user name");
                ValidInput = false;
            }else
            {
                ValidInput = true;
            }

        }while (!ValidInput);

        Console.WriteLine("Please enter the user's role Admin/Supervisor/Agent");
        UserRole = Console.ReadLine()?? "";

        Users.Add(new User(UserName, UserRole));

    }
}