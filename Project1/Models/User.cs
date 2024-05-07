namespace Project1.Models;

public class User
{

    //Fields
    public Guid UserId {get; set;}
    public string UserName {get; set;}

    public string UserRole {get; set;} //can only be Supervisor, Admin or Agent, if not Supervisor or Admin then automatically set to Agent

    //Constructors
    public User() {}

    public User(string UserName, string UserRole)
    {
        this.UserId = Guid.NewGuid();
        this.UserName = UserName;
        if(UserRole == "Supervisor")
        {
            this.UserRole = "Supervisor";
        }
        else if(UserRole == "Admin")
        {
            this.UserRole = "Admin";
        }
        else
        {
            this.UserRole = "Agent";
        }
        
    }

    public override string ToString()
    {

        return $"UserName: {UserName}\tUserRole: {UserRole}\tUserId: {UserId}";
        
    }
}