using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;

namespace Application.Common.Interfaces.Persistence;

public interface ITxRepo
{
    Task AddTxAsync(Tx transaction);
    Task<Tx?> GetByIdAsync(Guid id);
    Task<List<Tx>> GetTxByUserIdAsync(Guid userId);
    Task<List<Tx>> GetTxByUserIdAsync(
        Guid userId, 
        List<TransactionType> types);
}