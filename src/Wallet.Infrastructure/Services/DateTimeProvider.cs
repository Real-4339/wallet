using Wallet.Application.Common.Interfaces.Services;

namespace Wallet.Application.Common.Interfaces.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}