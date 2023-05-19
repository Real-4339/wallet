using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.Enums;
using Domain.TransactionsAggregate;
using Application.Common.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Commands.Transactions;

public class CreditTxCommandHandler : IRequestHandler<CreditTxCommand, StatusResult>
{
    private readonly ITxRepo _transactionRepository;
    private readonly IUserRepo _userRepository;

    public CreditTxCommandHandler(
        ITxRepo transactionRepository,
        IUserRepo userRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
    }

    public async Task<StatusResult> Handle(CreditTxCommand request, CancellationToken cancellationToken)
    {      
        await Task.CompletedTask;

        // Check if user exists
        if (_userRepository.GetUserById(request.UserId) is not User user)
        {
            throw new HttpRequestException("Sowwy");
        }
        
        // Generate transaction type and state
        var tx_type = (TransactionType)Enum.Parse(typeof(TransactionType), request.Type, true);
        var tx_state = (TransactionState)Enum.Parse(typeof(TransactionState), "accepted", true);
        
        var tx = Tx.Create(
            user.Id,
            request.Amount,
            tx_type,
            tx_state
        );

        // Add transaction to transaction repo
        _transactionRepository.AddTx(tx);

        // Add transaction to user wallet
        user.AddTransaction(tx.Id, tx.Amount, tx.Type);

        return new StatusResult("accepted");
    }
}