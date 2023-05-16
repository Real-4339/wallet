using Wallet.Application.Common.Interfaces.Persistence;
using Wallets.Domain.User.Entities;

namespace Wallets.Infrastucture.Persistence;

public class UserRepo : IUserRepo
{
    private readonly List<User> _users = new();

    public User? GetUserById(Guid id)
    {
        return _users.SingleOrDefault(u => u.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return _users.SingleOrDefault(u => u.Username == username);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public int GetLength()
    {
        return _users.Count;
    }
}