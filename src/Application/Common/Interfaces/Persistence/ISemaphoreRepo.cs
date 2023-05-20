namespace Application.Common.Interfaces.Persistence;

public interface ISemaphoreRepo
{
    SemaphoreSlim semaphore { get; }

    Task WaitAsync(CancellationToken cancellationToken = default);
}