namespace Project1.Controllers;

using Project1.Models;

class ProcessUserMenuItems
{
    public static void RemoveUser(List<User> Users, int intIndex)
    {
        Users.RemoveAt(intIndex);

    }

    public static void BulkUsers(List<User> Users)
    {
        //User 0
        Users.Add(new User("MiHorn", "Admin"));

        //User 1
        Users.Add(new User("CKnox", "Supervisor"));

        //User 2
        Users.Add(new User("RWheatley", "Agent"));

        //User 3
        Users.Add(new User("OFlores", "Omar"));


    }
}