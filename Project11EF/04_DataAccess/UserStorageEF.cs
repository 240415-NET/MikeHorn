using Microsoft.EntityFrameworkCore;
using Project11EF.API.Models;

namespace Project11EF.API.Data;

public class UserStorageEF : IUserStorageEF
{
    private readonly Project11EFContext userContext;

    public UserStorageEF(Project11EFContext userContextFromBuilder)
    {
        userContext = userContextFromBuilder;
    }

    public async Task<User?> GetUserByNamefromDBAsync(string usernametoFindFromUserService)
    {
        User? foundUser = await userContext.Users.SingleOrDefaultAsync(user => user.UserName == usernametoFindFromUserService);

        return foundUser;
    }

    public async Task<User> CreateUserInDBAsync(User newUserFromUserService)
    {
        userContext.Users.Add(newUserFromUserService);

        await userContext.SaveChangesAsync();

        return newUserFromUserService;
    }

    public async void DeleteUserFromDBAsync(User userFromUserService)
    {
        userContext.Users.Remove(userFromUserService);
        await userContext.SaveChangesAsync();
    }
}

