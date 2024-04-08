namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arrange

        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            null,
            "Kowalski",
            "kow@kow.com",
            DateTime.Parse("2000-01-01"),
            123);

        //Assert
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenSecondNameIsEmpty()
    {
        //Arrange

        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            "Jan",
            null,
            "kow@kow.com",
            DateTime.Parse("2000-01-01"),
            123);

        //Assert
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenEmailIsInWrongFormat()
    {
        //Arrange

        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kow-kow-com",
            DateTime.Parse("2000-01-01"),
            123);

        //Assert
        
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange

        var userService = new UserService();

        //Act

        

        var action = () => {userService.AddUser(
            "Jan",
            "Kowalski",
            "kow@kow.com",
            DateTime.Parse("2000-01-01"),
            100);};
        
        //Assert
        
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenUserIsYoungerThanTwentyTwo()
    {
        //Arrange
        var userService = new UserService();

        //Act
        DateTime ago = DateTime.Now.AddYears(-21).AddDays(1);
        var result = userService.AddUser("Jan", "Kowalski", "kow@kow.com", ago, 123);

        //Assert
        Assert.False(result);
    }
    
    //dot Cover potem tests coverAll
    
    //najpierw nadpisac wszystkie testy
    //potem zrobic refactor addusera
    [Fact]
    public void METHOD()
    {
        
    }
}