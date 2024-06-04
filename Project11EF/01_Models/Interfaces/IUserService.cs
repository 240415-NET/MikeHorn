namespace Project11EF.API.Models;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User newUserFromController);
    public Task<User> GetUserByUsernameAsync(string usernameToFindFromController);

    public Task<bool> UserExists(string userNameFromCreateNewUserAsync);
}