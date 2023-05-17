using Application.Auth.Common;
using MediatR;

namespace Application.Auth.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password
) : IRequest<AuthRegResult>;