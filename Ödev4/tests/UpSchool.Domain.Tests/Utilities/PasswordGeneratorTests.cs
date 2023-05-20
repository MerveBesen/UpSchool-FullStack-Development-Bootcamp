using FakeItEasy;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Utilities;

public class PasswordGeneratorTests
{

    [Fact]
    public void Generate_ShouldReturnEmptyString_WhenNoCharactersAreIncluded()
    {
        
        // Arrange

        var passwordGenerator = new PasswordGenerator();

        var generatePassworDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = false,
            IncludeLowercaseCharacters = false,
            IncludeUppercaseCharacters = false,
            IncludeSpecialCharacters = false,
        };


        // Act

        var password = passwordGenerator.Generate(generatePassworDto);

        // Assert
    
        Assert.Equal(string.Empty,password);


    }

    [Fact]
    public void Generate_ShouldReturnPasswordWithGivenLenght()
    {
        
        // Arrange

        var ipHelper = A.Fake<IIPHelper>();
        
        A.CallTo(() => ipHelper.GetCurrentIPAddress()).Returns("195.142.70.227");

        var localDbMock = A.Fake<ILocalDB>();

        A.CallTo(() => localDbMock.IPs).Returns(new List<string>()
        {
            "192.168.1.111",
            "156.153.15.5",
            "456.54.62.1"
        });
        
        //var localDb = new LocalDb();
        
        var passwordGenerator = new PasswordGenerator(ipHelper,localDbMock);

        var generatePassworDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = true,
            IncludeLowercaseCharacters = true,
            IncludeUppercaseCharacters = true,
            IncludeSpecialCharacters = true,
        };
        
        // Act
        var password = passwordGenerator.Generate(generatePassworDto);

        
        // Assert
        Assert.Equal(generatePassworDto.Length,password.Length);

        
    }
    
    [Fact]
    public void Generate_ShouldIncludeNumbers_WhenIncludeNumbersIsTrue()
    {
        
        // Arrange
        
        var passwordGenerator = new PasswordGenerator();

        var generatePassworDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = true,
            IncludeLowercaseCharacters = false,
            IncludeUppercaseCharacters = true,
            IncludeSpecialCharacters = true,
        };
        
        // Act
        var password = passwordGenerator.Generate(generatePassworDto);

        
        // Assert
        Assert.Contains(password, x => char.IsDigit(x));

    }
    
    [Fact]
    public void Generate_ShouldIncludeLowercaseCharacters_WhenLowercaseCharactersIsTrue()
    {
        
        // Arrange
        
        var passwordGenerator = new PasswordGenerator();

        var generatePasswordDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = true,
            IncludeLowercaseCharacters = true,
            IncludeUppercaseCharacters = true,
            IncludeSpecialCharacters = true,
        };
        
        // Act
        var password = passwordGenerator.Generate(generatePasswordDto);

        
        // Assert
        Assert.Contains(password, x => char.IsLower(x));

    }
    
    [Fact]
    public void Generate_ShouldIncludeUppercaseCharacters_WhenUppercaseCharactersIsTrue()
    {
        
        // Arrange
        
        var passwordGenerator = new PasswordGenerator();

        var generatePasswordDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = true,
            IncludeLowercaseCharacters = true,
            IncludeUppercaseCharacters = true,
            IncludeSpecialCharacters = true,
        };
        
        // Act
        var password = passwordGenerator.Generate(generatePasswordDto);

        
        // Assert
        Assert.Contains(password, x => char.IsUpper(x));

    }

    [Fact]
    public void Generate_ShouldIncludeSpecialCharacters_WhenSpecialCharactersIsTrue() 
    {
        
        // Arrange
        
        var passwordGenerator = new PasswordGenerator();

        var generatePasswordDto = new GeneratePasswordDto()
        {
            Length = 20,
            IncludeNumbers = true,
            IncludeLowercaseCharacters = true,
            IncludeUppercaseCharacters = true,
            IncludeSpecialCharacters = true,
        };

        var specialCharacters = "!@#$%^&*()";
        
        // Act
        var password = passwordGenerator.Generate(generatePasswordDto);

        
        // Assert
        Assert.Contains(password, x => specialCharacters.Contains(x));

    }
    
}