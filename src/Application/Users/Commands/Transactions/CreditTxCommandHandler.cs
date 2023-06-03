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
        if (_userRepository.GetUserById(request.UserId) is not User user)
        {
            throw new HttpRequestException("Sowwy");
        }
        
        Tx? transac = default!;

        if (request.TxId != Guid.Empty)
        {   
            transac = _transactionRepository.GetById(request.TxId);
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

        await _semaphore.TxWaitAsync(cancellationToken);

        try {
            // Add transaction to transaction repo
            _transactionRepository.AddTx(tx);

            // Add transaction to user wallet
            var res = user.AddTransaction(tx.Id, tx.Amount, tx.Type);

            if (!res)
            {
                tx.UpdateState(TransactionState.Rejected);
                return new StatusResult("rejected");
            }

            return new StatusResult("accepted");
        }
        finally
        {
            _semaphore.TxSemaphore.Release();
        }
    }
}