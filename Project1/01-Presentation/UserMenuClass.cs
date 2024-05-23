
using Project1.Models;
using Project1.Controllers;


namespace Project1.Presentation;
public class UserMenuClass
{
    public static List<User> Users = new List<User>();
    private static bool Continue = true;

    public static void UserMenu()
    {
        string[] strMainMenuItems = { "exit", "list users", "add user", "remove a user", "search for a user" };
        
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
                    Users = ProcessUserMenuItems.GetUsers();

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
                case 2: //add user
                    Users.Clear();
                    AddUser(Users);

                    Console.WriteLine("User has now been added \n");

                    break;
                case 3: //remove a user
                    Console.WriteLine("Please enter the User's Index Number to remove");
                    ProcessUserMenuItems.RemoveUser(Users, Convert.ToInt16(Console.ReadLine()));



                    Console.WriteLine("User has now been removed \n");

                    break;
                    case 4: //search for user using SQL
                        
                        Console.WriteLine("What is the User Name you are searching for?");
                        string strUserName = Console.ReadLine();

                        Users = ProcessUserMenuItems.RetrieveUser(strUserName);

                        if(Users.Count == 0) //Users not found
                        {
                            Console.WriteLine("User was not found");

                        }else
                        {
                            foreach(User theUser in Users)
                            {
                                Console.WriteLine(theUser);
                            }
                        } 
                        break;
                //XXX Obsolete needed for JSON
                // case 4: //search for a user with LINQ 
                //             Users = ProcessUserMenuItems.GetUsers(Users);

                //             Console.WriteLine("What are you searching for?");
                //             string strUserName = Console.ReadLine();

                //             List<User> subsetUsers = ProcessUserMenuItems.RetrieveUser(Users, strUserName);

                //             if(subsetUsers == null || subsetUsers.Count == 0) //user not found
                //             {
                //                 Console.WriteLine("Entered user was not found");
                //             }else //user(s) found
                //             {
                //                 foreach(User theUser in subsetUsers)
                //                 {
                //                     Console.WriteLine(theUser);
                //                 }
                //             }
                           
                //             break;

            }
        }
        catch (Exception excp)
        {
            Console.WriteLine("Error in UserMenuClass.ProcessUserMenu");
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

        ProcessUserMenuItems.SetUsers(Users, UserName, UserRole);

    }
}