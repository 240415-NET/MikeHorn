using Project11EF.API.Services;

namespace Project11EF.API.Models;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User newUserFromController);
    public Task<User> GetUserByUsernameAsync(User userToFindFromController);
}