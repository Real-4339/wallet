using Wallet.Application.Common.Interfaces.Persistence;
using Wallet.Application.Common.Interfaces.Auth;
using Wallets.Domain.User.Entities;

namespace Wallet.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepo _authRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepo authRepository
        )
    {   
        _authRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthRegResult Register(string firstName, string lastName, string Email, string Username, string Password)
    {      
        // Check if user exists
        Console.WriteLine(_authRepository.GetLength());
        if (_authRepository.GetUserByUsername(Username) is not null)
        {
            throw new Exception("Username already exists");
        }

        // Create a new user
        var user = new User
        {
            Id = Guid.NewGuid(),
            firstName = firstName,
            lastName = lastName,
            Email = Email,
            Username = Username,
            Password = Password
        };
        
        _authRepository.AddUser(user);
        Console.WriteLine(_authRepository.GetLength());
        // Generate a new token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthRegResult(user, token);
    }

    public AuthLogResult Login(string username, string password)
    {
        // Check if user exists
        User user = _authRepository.GetUserByUsername(username) as User
            ?? throw new Exception("User not found");

        // Validate password
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        return new AuthLogResult("success");
    }

}