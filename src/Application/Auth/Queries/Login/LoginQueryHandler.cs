
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Auth;
using Application.Auth.Common;
using Domain.User.Entities;
using MediatR;

namespace Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthLogResult>
{
    private readonly IUserRepo _authRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepo authRepository
        )
    {   
        _authRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthLogResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {   
        await Task.CompletedTask;

        // Check if user exists
        User user = _authRepository.GetUserByUsername(query.Username) as User
            ?? throw new UnauthorizedAccessException("Unauthorized");

        // Validate password
        if (user.Password != query.Password)
        {
            throw new UnauthorizedAccessException("Unauthorized");
        }

        return new AuthLogResult("success");
    }
}