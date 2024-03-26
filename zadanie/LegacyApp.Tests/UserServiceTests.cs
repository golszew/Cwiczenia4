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
    
    //dot Cover potem tests coverAll
    
    //najpierw nadpisac wszystkie testy
    //potem zrobic refactor addusera
}