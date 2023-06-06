using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Application.Auth.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthRegResult>
{
    private readonly IUserRepo _authRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepo authRepository
        )
    {   
        _authRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<AuthRegResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {   
         // Check if user exists
        if (await _authRepository.GetUserByUsernameAsync(command.Username) is not null)
        {
            throw new Exception("Internal Server Error");
        }

        // Change password to hash
        var passwordHasher = new PasswordHasher<string>();
        var HashedPass = passwordHasher.HashPassword(command.Username, command.Password);

        // Create a new user
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Username,
            HashedPass
        );
        
        await _authRepository.AddUserAsync(user);

        // Generate a new token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthRegResult(user, token);
    }
}