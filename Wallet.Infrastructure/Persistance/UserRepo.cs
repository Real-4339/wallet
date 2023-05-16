using Wallet.Application.Common.Interfaces.Persistence;
using Wallet.Domain.User.Entities;

namespace Wallet.Infrastucture.Persistence;

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
}