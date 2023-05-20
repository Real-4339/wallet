using FluentValidation;
using MediatR;

namespace Application.Users.Queries.Transactions;

public class GetTxBehavior
        : IPipelineBehavior<GetTxQuery, GetTxResult>
{

    private readonly IValidator<GetTxQuery> _validator;

    public GetTxBehavior(IValidator<GetTxQuery> validator)
    {
        _validator = validator;
    }

    public async Task<GetTxResult> Handle(
        GetTxQuery request,
        RequestHandlerDelegate<GetTxResult> next,
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