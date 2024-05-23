namespace Project1.Models;

public interface IUserDataManagement
{
    //XXX Obsolete used for JSON
    // public List<User> RetrieveData(List<User> Users);
    public List<User> RetrieveData();
    
    //XXX Obsolete used for JSON
    // public  void StoreData(List<User> PassedListOfUsers, bool refresAll);
    public void StoreData(User PassedfUser, bool refresAll);
    
    //XXX Obsolete used for JSON
    // public List<User> FindUser(List<User> Users, string userName);
    public List<User> FindUser(string userName);

    public void DeleteData(Guid Id);
    

}