using Application.Auth.Commands.Register;
using Application.Auth.Common;
using FluentValidation;
using MediatR;

namespace Application.Auth.Behaviors;

public class RegisterValidationCommandBehaviour :
    IPipelineBehavior<RegisterCommand, AuthRegResult>
{   
    private readonly IValidator<RegisterCommand> _validator;

    public RegisterValidationCommandBehaviour(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<AuthRegResult> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<AuthRegResult> next,
        CancellationToken cancellationToken)
    {   
        var result = await _validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        return await next();
    }
}