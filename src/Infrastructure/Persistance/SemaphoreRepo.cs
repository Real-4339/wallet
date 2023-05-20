using Application.Common.Interfaces.Persistence;

namespace Infrastucture.Persistence;

public class SemaphoreRepo : ISemaphoreRepo
{
    public SemaphoreSlim semaphore { get; } = new SemaphoreSlim(1, 1);

    public async Task WaitAsync(CancellationToken cancellationToken = default)
    {
        await semaphore.WaitAsync(cancellationToken);
    }
}