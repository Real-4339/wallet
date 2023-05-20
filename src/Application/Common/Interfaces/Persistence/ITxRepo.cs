using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;

namespace Application.Common.Interfaces.Persistence;

public interface ITxRepo
{
    void AddTx(Tx transaction);
    Tx? GetById(Guid id);
    List<Tx> GetTxByUserId(Guid userId);
    List<Tx> GetTxByUserId(
        Guid userId, 
        List<TransactionType> types);
}