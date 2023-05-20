using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;

namespace Infrastucture.Persistence;

public class TxRepo : ITxRepo
{   
    private readonly List<Tx> _transactions = new();
    public void AddTx(Tx transaction)
    {
        _transactions.Add(transaction);
    }

    public Tx? GetById(Guid id)
    {
        return _transactions.SingleOrDefault(t => t.Id.Value == id);
    }

    public List<Tx> GetTxByUserId(Guid userId)
    {
        return _transactions.Where(t => t.UserId.Value == userId).ToList();
    }

    public List<Tx> GetTxByUserId(Guid userId, List<TransactionType> types)
    {
        return _transactions
            .Where(t => t.UserId.Value == userId)
            .Where(t => types.Contains(t.Type))
            .ToList();
    }
}