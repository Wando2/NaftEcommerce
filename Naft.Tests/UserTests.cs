
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Naft.Tests;

public class UserTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly PasswordHash _password;
    private readonly User _user;
    
    public UserTests()
    {
        _name = new Name("John", "Silva");
        _email = new Email("John@gmail.com");
        _password = new PasswordHash("123456789");
        _user = new User(_name, _email, _password);
    }
    
    
    [Fact]
    public void ShouldBeInvalidWhenNameIsNull()
    {
        var name = new Name(null, "Silva");
        var email = new Email("silva@gmail.com");
        var password = new PasswordHash("123456789");
        var user = new User(name, email, password);
        Assert.False(user.IsValid);
    }

    [Fact]
    public void ShouldBeInvalidWhenEmailIsNull()
    {
        var email = new Email(null);
        var user = new User(_name, email, _password);
        Assert.False(user.IsValid);
    }
    
    [Fact(DisplayName = "Should be invalid when password is null")]
    public void ShouldBeInvalidWhenPasswordIsNull()
    {
        var password = new PasswordHash(null);
        var user = new User(_name, _email, password);
        Assert.False(user.IsValid);
    }
    
    [Fact(DisplayName = "Should be valid when all properties are valid")]
    public void ShouldBeValidWhenAllPropertiesAreValid()
    {
        Assert.True(_user.IsValid);
    }
    
    
    
}