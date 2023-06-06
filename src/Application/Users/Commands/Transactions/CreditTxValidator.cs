using FluentValidation;

namespace Application.Users.Commands.Transactions;

public class CreditTxValidator : AbstractValidator<CreditTxCommand>
{   
    public CreditTxValidator()
    {   
        // Only takes win, stake, credit.
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Transaction is required")
            .Must(x => x.ToLower() == "win" || x.ToLower() == "stake" || x.ToLower() == "deposit")
                    .WithMessage("Transaction must be win, stake, or deposit");
    }
}