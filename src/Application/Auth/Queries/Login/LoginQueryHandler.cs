
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Application.Common.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, StatusResult>
{
    private readonly IUserRepo _authRepository;
    private readonly ISemaphoreRepo _semaphore;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepo authRepository,
        ISemaphoreRepo semaphore)
    {   
        _authRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _semaphore = semaphore;
    }

    public async Task<StatusResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {   
        // Check if user exists
        User user = await _authRepository.GetUserByUsernameAsync(query.Username) as User
            ?? throw new UnauthorizedAccessException("Unauthorized");

        // Validate password
        var verifyPassword = new PasswordHasher<string>().VerifyHashedPassword(
            user.Username,
            user.Password,
            query.Password
        );
        if (verifyPassword == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Unauthorized");
        }
        else if (verifyPassword == PasswordVerificationResult.SuccessRehashNeeded)
        {   
            await RehashPassword(user, query.Password);
        }

        return new StatusResult("success");
    }

    // Move this to a service
    async Task RehashPassword(User user, string password)
    {
        // Change password to hash
        var passwordHasher = new PasswordHasher<string>();
        var HashedPass = passwordHasher.HashPassword(user.Username, password);

        // Update user password
        try {
            await _semaphore.UserWaitAsync();
            
            user.Update(
            password: HashedPass
            );
        }
        finally {
            _semaphore.UserSemaphore.Release();
        }

        await Task.CompletedTask;
    }
}