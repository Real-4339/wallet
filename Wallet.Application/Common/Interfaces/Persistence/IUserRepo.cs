using Wallets.Domain.User.Entities;

namespace Wallet.Application.Common.Interfaces.Persistence;

public interface IUserRepo
{
    User? GetUserById(Guid id);
    User? GetUserByUsername(string username);
    void AddUser(User user);
    int GetLength();
}