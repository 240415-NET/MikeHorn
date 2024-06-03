using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        else
        {
            User? foundUser = await userStorageEFObject.GetUserByNamefromDBAsync(newUserFromController);

            if (foundUser == null)
            {
                throw new Exception("User not found in DB?");
            }

            await userStorageEFObject.CreateUserInDBAsync(foundUser);

            return foundUser;
        }

    }

    public async Task<User> GetUserByUsernameAsync(User userToFindFromController)
    {
        //Check validity of the username
        if (String.IsNullOrEmpty(userToFindFromController.UserName) == true)
        {
            throw new Exception("Username cannot be blank.");
        }
        else if (String.IsNullOrEmpty(userToFindFromController.UserRole) == true)
        {
            throw new Exception("User role cannot be blank.");
        }
        else
        {
            try
            {
                User? foundUser = await userStorageEFObject.GetUserByNamefromDBAsync(userToFindFromController);

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
}