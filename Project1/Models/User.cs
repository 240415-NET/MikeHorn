namespace Project1.Models;

public class User
{

    //Fields
    public Guid UserId {get; private set;}
    public string UserName {get; set;}

    public string UserRole {get; private set;} //can only be Supervisor or Agent, if not Supervisor then automatically set to Agent

    //Constructors
    // public User() {}

    public User(string UserName, string UserRole)
    {
        this.UserId = Guid.NewGuid();
        this.UserName = UserName;
        if(UserRole == "Supervisor")
        {
            this.UserRole = "Supervisor";
        }
        else
        {
            this.UserRole = "Agent";
        }
        
    }

}