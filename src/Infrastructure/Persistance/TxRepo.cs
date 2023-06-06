using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;

namespace Infrastucture.Persistence;

public class TxRepo : ITxRepo
{   
    private readonly List<Tx> _transactions = new();

    private readonly SemaphoreSlim UserRepoSemaphore = new SemaphoreSlim(1, 1);
    
    public async Task AddTxAsync(Tx transaction)
    {   
        await UserRepoSemaphore.WaitAsync();
        _transactions.Add(transaction);
        UserRepoSemaphore.Release();
    }

    public async Task<Tx?> GetByIdAsync(Guid id)
    {   
        await UserRepoSemaphore.WaitAsync();
        
        Tx? a = _transactions.SingleOrDefault(t => t.Id.Value == id);
        
        UserRepoSemaphore.Release();
        
        return a;
    }

    public async Task<List<Tx>> GetTxByUserIdAsync(Guid userId)
    {   
        await UserRepoSemaphore.WaitAsync();
        
        List<Tx> a = _transactions
                        .Where(t => t.UserId.Value == userId)
                        .ToList();
        
        UserRepoSemaphore.Release();
        
        return a;
    }

    public async Task<List<Tx>> GetTxByUserIdAsync(Guid userId, List<TransactionType> types)
    {
        await UserRepoSemaphore.WaitAsync();
        
        List<Tx> a = _transactions
            .Where(t => t.UserId.Value == userId)
            .Where(t => types.Contains(t.Type))
            .ToList();
        
        UserRepoSemaphore.Release();
        
        return a;
    }
}