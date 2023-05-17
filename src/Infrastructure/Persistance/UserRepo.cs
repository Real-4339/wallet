using Application.Common.Interfaces.Persistence;
using Domain.User.Entities;

namespace Infrastucture.Persistence;

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