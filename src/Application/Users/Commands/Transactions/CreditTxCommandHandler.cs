using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.ValueObjects;
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
    private readonly ISemaphoreRepo _semaphore;

    public CreditTxCommandHandler(
        ITxRepo transactionRepository,
        IUserRepo userRepository,
        ISemaphoreRepo TxSemaphore)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
        _semaphore = TxSemaphore;
    }

    public async Task<StatusResult> Handle(CreditTxCommand request, CancellationToken cancellationToken)
    {      

        // Check if user exists
        if (await _userRepository.GetUserByIdAsync(request.UserId) is not User user)
        {
            throw new HttpRequestException("Sowwy");
        }
        
        Tx? transac = default!;

        if (request.TxId != Guid.Empty)
        {   
            transac = await _transactionRepository.GetByIdAsync(request.TxId);
            // Check if transaction exists
            if (transac is Tx)
            {
                return new StatusResult(transac.State.ToString());
            }
        }
        
        // Generate transaction type and state
        var tx_type = (TransactionType)Enum.Parse(typeof(TransactionType), request.Type, true);
        var tx_state = (TransactionState)Enum.Parse(typeof(TransactionState), "accepted", true);
        
        Tx tx = default!;

        if (request.TxId != Guid.Empty)
        {

            TxId txId = TxId.From(request.TxId);

            tx = Tx.Create(
            user.Id,
            txId,
            request.Amount,
            tx_type,
            tx_state);
        }
        else {
            tx = Tx.Create(
            user.Id,
            request.Amount,
            tx_type,
            tx_state);
        }

        // Add transaction to transaction repo
        await _transactionRepository.AddTxAsync(tx);

        var res = false;

        // Add transaction to user wallet
        try {
            await _semaphore.WalletWaitAsync();

            res = user.AddTransaction(tx.Id, tx.Amount, tx.Type);
        }
        finally {
            _semaphore.WalletSemaphore.Release();
        }

        if (!res)
        {
            tx.UpdateState(TransactionState.Rejected);
            return new StatusResult("rejected");
        }

        return new StatusResult("accepted");
    }
}