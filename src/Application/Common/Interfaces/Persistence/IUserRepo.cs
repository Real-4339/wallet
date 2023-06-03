using Domain.UserAggregate;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepo
{
    User? GetUserById(Guid id);
    User? GetUserByUsername(string username);
    void UpdateUser(User user);
    void AddUser(User user);
}