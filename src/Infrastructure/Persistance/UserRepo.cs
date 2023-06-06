using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;

namespace Infrastucture.Persistence;

public class UserRepo : IUserRepo
{
    private readonly List<User> _users = new();

    private readonly SemaphoreSlim UserRepoSemaphore = new SemaphoreSlim(1, 1);

    public async Task<User?> GetUserByIdAsync(Guid id)
    {   
        await UserRepoSemaphore.WaitAsync();
        
        User? a = _users.SingleOrDefault(u => u.Id.Value == id);
        
        UserRepoSemaphore.Release();

        return a;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        await UserRepoSemaphore.WaitAsync();
        
        User? a = _users.SingleOrDefault(u => u.Username == username);
        
        UserRepoSemaphore.Release();
        
        return a;
    }

    public async Task AddUserAsync(User user)
    {   
        await UserRepoSemaphore.WaitAsync();
        
        _users.Add(user);
        
        UserRepoSemaphore.Release();
    }
}