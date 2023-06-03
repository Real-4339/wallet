namespace Application.Common.Interfaces.Persistence;

public interface ISemaphoreRepo
{
    SemaphoreSlim TxSemaphore { get; }

    SemaphoreSlim LoginSemaphore { get; }

    Task TxWaitAsync(CancellationToken cancellationToken = default);

    Task LoginWaitAsync(CancellationToken cancellationToken = default);
}