using Application.Auth.Common;
using MediatR;

namespace Application.Auth.Commands.Register;

public record RegisterCommand(
    string firstName,
    string lastName,
    string Email,
    string Username,
    string Password
) : IRequest<AuthRegResult>;