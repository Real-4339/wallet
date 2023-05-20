using Application.Common.Results;
using FluentValidation;
using MediatR;

namespace Application.Users.Commands.Transactions;

public class TransactionBehavior
        : IPipelineBehavior<CreditTxCommand, StatusResult>
{
    private readonly IValidator<CreditTxCommand> _validator;

    public TransactionBehavior(IValidator<CreditTxCommand> validator)
    {
        _validator = validator;
    }

    public async Task<StatusResult> Handle(
        CreditTxCommand request,
        RequestHandlerDelegate<StatusResult> next,
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