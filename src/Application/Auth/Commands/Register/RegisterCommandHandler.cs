using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Auth;
using Application.Auth.Common;
using Domain.User.Entities;
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
        await Task.CompletedTask;

         // Check if user exists
        if (_authRepository.GetUserByUsername(command.Username) is not null)
        {
            throw new Exception("Internal Server Error");
        }

        // Create a new user
        var user = new User
        {
            Id = Guid.NewGuid(),
            firstName = command.FirstName,
            lastName = command.LastName,
            Email = command.Email,
            Username = command.Username,
            Password = command.Password
        };
        
        _authRepository.AddUser(user);

        // Generate a new token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthRegResult(user, token);
    }
}