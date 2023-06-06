using Application.Common.Interfaces.Persistence;

namespace Infrastucture.Persistence;

public class SemaphoreRepo : ISemaphoreRepo
{
    public SemaphoreSlim WalletSemaphore { get; } = new SemaphoreSlim(1, 1);

    public SemaphoreSlim UserSemaphore { get; } = new SemaphoreSlim(1, 1);

    public async Task WalletWaitAsync(CancellationToken cancellationToken = default)
    {
        await WalletSemaphore.WaitAsync(cancellationToken);
    }

    public async Task UserWaitAsync(CancellationToken cancellationToken = default)
    {
        await UserSemaphore.WaitAsync(cancellationToken);
    }
}