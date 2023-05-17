using Domain.User.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepo
{
    User? GetUserById(Guid id);
    User? GetUserByUsername(string username);
    void AddUser(User user);
}