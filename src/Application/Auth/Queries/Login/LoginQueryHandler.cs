
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Auth;
using Application.Common.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, StatusResult>
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

    public async Task<StatusResult> Handle(LoginQuery query, CancellationToken cancellationToken)
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

        return new StatusResult("success");
    }
}