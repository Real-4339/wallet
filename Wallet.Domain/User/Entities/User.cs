namespace Wallets.Domain.User.Entities;

public class User
{
    public Guid Id { get; set; }
    public string firstName { get; set; } = null!;
    public string lastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}