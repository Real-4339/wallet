using Domain.Common.Primitives;
using Domain.User.ValueObjects;

namespace Domain.User;

public class User // : AggregateRoot<UserId>
{
    public Guid Id { get; set; }
    public string firstName { get; set; } = null!;
    public string lastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}