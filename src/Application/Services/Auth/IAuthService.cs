namespace Application.Services.Auth;

public interface IAuthCommandService
{
    AuthRegResult Register(string firstName, string lastName, string Email, string Username, string Password);
    AuthLogResult Login(string Username, string Password);
} 