using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;

namespace Infrastucture.Persistence;

public class UserRepo : IUserRepo
{
    private readonly List<User> _users = new();

    private readonly SemaphoreSlim TxRepoSemaphore = new SemaphoreSlim(1, 1);

    public async Task<User?> GetUserByIdAsync(Guid id)
    {   
        await TxRepoSemaphore.WaitAsync();
        
        User? a = _users.SingleOrDefault(u => u.Id.Value == id);
        
        TxRepoSemaphore.Release();

        return a;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        await TxRepoSemaphore.WaitAsync();
        
        User? a = _users.SingleOrDefault(u => u.Username == username);
        
        TxRepoSemaphore.Release();
        
        return a;
    }

    public async Task AddUserAsync(User user)
    {   
        await TxRepoSemaphore.WaitAsync();
        
        _users.Add(user);
        
        TxRepoSemaphore.Release();
    }
}