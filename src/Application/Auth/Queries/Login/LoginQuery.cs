using Application.Common.Results;
using MediatR;

namespace Application.Auth.Queries.Login;

public record LoginQuery(
    string Username,
    string Password
) : IRequest<StatusResult>;