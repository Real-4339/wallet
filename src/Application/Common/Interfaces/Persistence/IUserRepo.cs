using Domain.UserAggregate;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepo
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user);
}