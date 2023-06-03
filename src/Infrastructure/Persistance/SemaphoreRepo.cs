using Application.Common.Interfaces.Persistence;

namespace Infrastucture.Persistence;

public class SemaphoreRepo : ISemaphoreRepo
{
    public SemaphoreSlim TxSemaphore { get; } = new SemaphoreSlim(1, 1);

    public SemaphoreSlim LoginSemaphore { get; } = new SemaphoreSlim(1, 1);

    public async Task TxWaitAsync(CancellationToken cancellationToken = default)
    {
        await TxSemaphore.WaitAsync(cancellationToken);
    }

    public async Task LoginWaitAsync(CancellationToken cancellationToken = default)
    {
        await LoginSemaphore.WaitAsync(cancellationToken);
    }
}