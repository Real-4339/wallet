using FluentValidation;

namespace Application.Users.Commands.Transactions;

public class CreditTxValidator : AbstractValidator<CreditTxCommand>
{
    public CreditTxValidator()
    {   
        // Only takes win, stake, credit.
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Transaction is required")
            .Must(x => x == "win" || x == "stake" || x == "credit")
                    .WithMessage("Transaction must be win, stake, or credit");
    }
}