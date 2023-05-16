using Wallet.Application.Common.Interfaces.Persistence;
using Wallet.Application.Common.Interfaces.Auth;
using Wallet.Domain.User.Entities;

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
        if (_authRepository.GetUserByUsername(Username) is not null)
        {
            throw new Exception("Internal Server Error");
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

        // Generate a new token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthRegResult(user, token);
    }

    public AuthLogResult Login(string username, string password)
    {
        // Check if user exists
        User user = _authRepository.GetUserByUsername(username) as User
            ?? throw new UnauthorizedAccessException("Unauthorized");

        // Validate password
        if (user.Password != password)
        {
            throw new UnauthorizedAccessException("Unauthorized");
        }

        return new AuthLogResult("success");
    }

}