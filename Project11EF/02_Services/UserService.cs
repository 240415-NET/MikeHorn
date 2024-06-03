// using Microsoft.CodeAnalysis.CSharp.Syntax;
using Project11EF.API.Models;

namespace Project11EF.API.Services;

public class UserService : IUserService
{
    //Declaration for Dependency Injection
    private readonly IUserStorageEF userStorageEFObject;

    public UserService(IUserStorageEF userStorageEFObjectfromBuilder)
    {
        userStorageEFObject = userStorageEFObjectfromBuilder;
    }

    public async Task<User> CreateNewUserAsync(User newUserFromController)
    {
        //Check validity of the username
        if (String.IsNullOrEmpty(newUserFromController.UserName) == true)
        {
            throw new Exception("Username cannot be blank.");
        }
        else if (String.IsNullOrEmpty(newUserFromController.UserRole) == true)
        {
            throw new Exception("User role cannot be blank.");
        }
        else if (Convert.ToBoolean(UserExists(newUserFromController.UserName)) == true)
        {
            await userStorageEFObject.CreateUserInDBAsync(newUserFromController);
            return newUserFromController;
            // User? foundUser = await userStorageEFObject.GetUserByNamefromDBAsync(newUserFromController.UserName);

            // if (foundUser != null)
            // {
            //     await userStorageEFObject.CreateUserInDBAsync(newUserFromController);
            //     return newUserFromController;
            // }
            // else
            // {
            //     throw new Exception("User not found in DB?");
            // }

        }else
        {
            throw new Exception("User not found in DB?");
        }

    }

    public async Task<User> GetUserByUsernameAsync(string usernameToFindFromController)
    {
        //Check validity of the username
        if (String.IsNullOrEmpty(usernameToFindFromController) == true)
        {
            throw new Exception("Username cannot be blank.");
        }
        else
        {
            try
            {
                User? foundUser = await userStorageEFObject.GetUserByNamefromDBAsync(usernameToFindFromController);

                if (foundUser == null)
                {
                    throw new Exception("User not found in DB?");
                }

                return foundUser;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }

    public async Task<bool> UserExists(string userNameFromCreateNewUserAsync)
    {
        User? foundUser = await userStorageEFObject.GetUserByNamefromDBAsync(userNameFromCreateNewUserAsync);
        if (foundUser == null)
        {
            return false;
        }else
        {
            return true;
        }
        
    }
}