namespace Application.Common.Interfaces.Persistence;

public interface ISemaphoreRepo
{
    SemaphoreSlim WalletSemaphore { get; }

    SemaphoreSlim UserSemaphore { get; }
    
    Task WalletWaitAsync(CancellationToken cancellationToken = default);

    Task UserWaitAsync(CancellationToken cancellationToken = default);
}