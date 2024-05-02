
using Project1.Models;
using Project1.DataAccess;

namespace Project1.Presentation;
public class AddUserClass
{
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
            }else if(UserStorage.UserExists(UserName))
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