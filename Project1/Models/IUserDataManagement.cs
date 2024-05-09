namespace Project1.Models;

public interface IUserDataManagement
{
    public List<User> RetrieveData(List<User> Users);
    
   
    public  void StoreData(List<User> PassedListOfUsers, bool refresAll);
    

    // public User FindData(string usernameToFind);

    public List<User> FindUser(List<User> Users, string userName);
    

}