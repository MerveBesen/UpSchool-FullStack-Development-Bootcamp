using FakeItEasy;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services;

public class UserServiceTests
{
    [Fact]
    public async Task GetUser_ShouldGetUserWithCorrectId()
    {
        
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

        var cancellationSource = new CancellationTokenSource();

        var expectedUser = new User()
        {

            Id = userId
        };
        
        A.CallTo(() => userRepositoryMock.GetByIdAsync(userId,cancellationSource.Token))
            .Returns(Task.FromResult(expectedUser));

        IUserService userService = new UserManager(userRepositoryMock);

        var user = await userService.GetByIdAsync(userId, cancellationSource.Token);
        
        Assert.Equal(expectedUser,user);

    }

    [Fact]
    public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
    {

        var userRepositoryMock = A.Fake<IUserRepository>();
            
            var cancellationSource = new CancellationTokenSource();
            
            var userService = new UserManager(userRepositoryMock);

            var expectedUser = new User
            {
                Email = null, 
            };

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await userService.AddAsync(expectedUser,cancellationSource.Token);
            });
        


    }

    [Fact]
    public async Task AddAsync_ShouldReturn_CorrectUserId()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);
        
        var cancellationSource = new CancellationTokenSource();

        Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

        var user = new User
        {
            
        };

        A.CallTo(() => userRepositoryMock.AddAsync(user,cancellationSource.Token))
            .Returns(Task.FromResult(userId));

        var resultUserId = await userService.AddAsync(user,cancellationSource.Token);

        Assert.Equal(userId, resultUserId);
    }


    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);

        var cancellationSource = new CancellationTokenSource();
        
        Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");
        
        A.CallTo(() => userRepositoryMock.DeleteAsync(userId,cancellationSource.Token))
            .Returns(true);

        var result = await userService.DeleteAsync(userId,cancellationSource.Token);

        Assert.True(result);
    }


    [Fact]
    public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExist()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);
        
        var cancellationSource = new CancellationTokenSource();

        var userId = Guid.NewGuid();

        A.CallTo(() => userRepositoryMock.DeleteAsync(userId,cancellationSource.Token)).Returns(false);

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await userService.DeleteAsync(userId,cancellationSource.Token);
        });
    }


    [Fact]
    public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);
        
        var cancellationSource = new CancellationTokenSource();

        var user = new User
        {
            Id = Guid.Empty, 
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await userService.UpdateAsync(user,cancellationSource.Token);
        });
    }


    [Fact]
    public async Task UpdateAsync_ShouldThrowException_WhenUserEmailIsEmptyOrNull()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);

        var cancellationSource = new CancellationTokenSource();
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = null, 
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await userService.UpdateAsync(user,cancellationSource.Token);
        });
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
    {
        var userRepositoryMock = A.Fake<IUserRepository>();
        
        var userService = new UserManager(userRepositoryMock);
        
        var cancellationSource = new CancellationTokenSource();

        var expectedUsers = new List<User>
        {
            new User { 
                FirstName = "Merve",
                LastName = "Besen",
                Age = 2,
                Email = "flkeşlrfkwş@gmail.com" 
            },
            new User { 
                FirstName = "abc",
                LastName = "kdncfl",
                Age = 15,
                Email = "mfpoefkrpf@gmail.com" 
            }
        };

        A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token)).Returns(expectedUsers);

        var userList = await userService.GetAllAsync(cancellationSource.Token);

        Assert.NotNull(userList);
        Assert.True(userList.Count >= 2);
    }

    
}