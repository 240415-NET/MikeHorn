namespace Project11EF.API.Models;

public interface IUserStorageEF
{
    public Task<User?> GetUserByNamefromDBAsync(string usernametoFindFromUserService);
    public Task<User> CreateUserInDBAsync(User newUserFromUserService);
}