

namespace Project11EF.API.Models;

public interface IUserStorageEF
{
    public Task<User?> GetUserByNamefromDBAsync(User usertoFindFromUserService);
    public Task<User> CreateUserInDBAsync(User newUserFromUserService);
}