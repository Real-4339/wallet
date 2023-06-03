using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;

namespace Infrastucture.Persistence;

public class UserRepo : IUserRepo
{
    private readonly List<User> _users = new();

    public User? GetUserById(Guid id)
    {
        return _users.SingleOrDefault(u => u.Id.Value == id);
    }

    public User? GetUserByUsername(string username)
    {
        return _users.SingleOrDefault(u => u.Username == username);
    }
    // new
    public void UpdateUser(User user)
    {
        var index = _users.FindIndex(u => u.Id.Value == user.Id.Value);
        _users[index] = user;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}