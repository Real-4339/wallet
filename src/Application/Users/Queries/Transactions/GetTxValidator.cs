using FluentValidation;

namespace Application.Users.Queries.Transactions;

public class GetTxValidator : AbstractValidator<GetTxQuery>
{
    public GetTxValidator()
    {
        RuleFor(x => x.Types)
            .NotEmpty().WithMessage("Transactions are required")
            .ForEach(tx =>
            {
                tx.NotEmpty().WithMessage("Transaction is required");
                tx.Must(x => x == "win" || x == "stake" || x == "credit")
                    .WithMessage("Transaction must be win, stake, or credit");
            });
    }
}