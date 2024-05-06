namespace Project1.Models;

public interface IUserStorage
{
    public List<User> RetrieveUsers(List<User> Users);

    public  void StoreUsers(List<User> PassedListOfUsers, bool refresAll);

    public User FindUser(string usernameToFind);

}