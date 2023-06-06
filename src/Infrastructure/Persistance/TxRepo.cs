using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;

namespace Infrastucture.Persistence;

public class TxRepo : ITxRepo
{   
    private readonly List<Tx> _transactions = new();

    private readonly SemaphoreSlim TxRepoSemaphore = new SemaphoreSlim(1, 1);
    
    public async Task AddTxAsync(Tx transaction)
    {   
        await TxRepoSemaphore.WaitAsync();
        _transactions.Add(transaction);
        TxRepoSemaphore.Release();
    }

    public async Task<Tx?> GetByIdAsync(Guid id)
    {   
        await TxRepoSemaphore.WaitAsync();
        
        Tx? a = _transactions.SingleOrDefault(t => t.Id.Value == id);
        
        TxRepoSemaphore.Release();
        
        return a;
    }

    public async Task<List<Tx>> GetTxByUserIdAsync(Guid userId)
    {   
        await TxRepoSemaphore.WaitAsync();
        
        List<Tx> a = _transactions
                        .Where(t => t.UserId.Value == userId)
                        .ToList();
        
        TxRepoSemaphore.Release();
        
        return a;
    }

    public async Task<List<Tx>> GetTxByUserIdAsync(Guid userId, List<TransactionType> types)
    {
        await TxRepoSemaphore.WaitAsync();
        
        List<Tx> a = _transactions
            .Where(t => t.UserId.Value == userId)
            .Where(t => types.Contains(t.Type))
            .ToList();
        
        TxRepoSemaphore.Release();
        
        return a;
    }
}