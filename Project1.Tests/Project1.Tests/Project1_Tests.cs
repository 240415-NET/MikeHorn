using Project1;
using Project1.Controllers;
using Project1.Presentation;
using System.Linq;

namespace Project1.Tests;

public class Project1_Tests
{
    // [Fact]
    // public void UserExists_False()
    // {
    //     //Arrange
        

    //     //Act
    //     bool testResult =  ProcessUserMenuItems.UserExists("aaa");

    //     //Assert
    //     Assert.False(testResult);
    // }

    // [Fact]
    // public void UserExists_True()
    // {
    //     //Arrange
        

    //     //Act
    //     bool testResult =  ProcessUserMenuItems.UserExists("OFlores");

    //     //Assert
    //     Assert.True(testResult);
    // }

    [Fact]
    public void MainMenu_Agent_UserRole_False()
    {
        //Arrange
        MainMenuClass main = new MainMenuClass();
        main.MainMenu("Agent", true);
        string shouldHave = "manage users";
        

        //Act
        bool testResult = main.strMainMenuItems.Contains(shouldHave);


        //Assert
        Assert.False(testResult);
    }

    [Fact]
    public void MainMenu_Admin_UserRole_True()
    {
        //Arrange
        MainMenuClass main = new MainMenuClass();
        main.MainMenu("Admin", true);
        string shouldHave = "manage users";
        

        //Act
        bool testResult = main.strMainMenuItems.Contains(shouldHave);


        //Assert
        Assert.True(testResult);
    }

    [Theory]
    [InlineData ("Admin")]
    public void VehicleMenu_Admin_ReturnTrue(string UserRole)
    {
        //Arrange
        // VehicleMenuClass VC = new VehicleMenuClass();
        VehicleMenuClass.VehicleMenu(UserRole, true);
        string shouldHave = "add bulk";
        

        //Act
        bool testResult = VehicleMenuClass.strVehicleMenuItems.Contains(shouldHave);


        //Assert
        Assert.True(testResult);
    }

    [Theory]
    [InlineData ("Agent")]
    [InlineData ("Supervisor")]
    public void VehicleMenu_NotAdmin_ReturnFalse(string UserRole)
    {
        //Arrange
        // VehicleMenuClass VC = new VehicleMenuClass();
        VehicleMenuClass.VehicleMenu(UserRole, true);
        string shouldHave = "add bulk";
        

        //Act
        bool testResult = VehicleMenuClass.strVehicleMenuItems.Contains(shouldHave);


        //Assert
        Assert.False(testResult);
    }
}