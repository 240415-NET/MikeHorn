using Project1;
using Project1.Controllers;
using Project1.Presentation;
using System.Linq;

namespace Project1.Tests;

public class Project1_Tests
{
    [Fact]
    public void UserExists_False()
    {
        //Arrange
        

        //Act
        bool testResult =  ProcessUserMenuItems.UserExists("aaa");

        //Assert
        Assert.False(testResult);
    }

    [Fact]
    public void UserExists_True()
    {
        //Arrange
        

        //Act
        bool testResult =  ProcessUserMenuItems.UserExists("OFlores");

        //Assert
        Assert.True(testResult);
    }

    [Fact]
    public void MainMenu_Agent_UserRole_False()
    {
        //Arrange
        MainMenuClass main = new MainMenuClass();
        main.MainMenu("Agent");
        string shouldHave = "manage users";
        // bool testResult = true;
        

        //Act
        // bool testResult =  main.MainMenu.strMainMenuItems.Contains("manage users");
        bool testResult = main.strMainMenuItems.Contains(shouldHave);
        // if(main.strMainMenuItems.Count() == 3)
        // {
        //     testResult = true;
        // }else
        // {
        //     testResult = false;
        // }
        

        //Assert
        // Console.WriteLine(testResult);
        Assert.False(testResult);
    }
}