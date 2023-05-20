using Application.Common.Interfaces.Persistence;
using Domain.TransactionsAggregate.Enums;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Queries.Transactions;

public class GetTxQueryHandler : IRequestHandler<GetTxQuery, GetTxResult>
{
    private readonly ITxRepo _transactionRepository;
    private readonly IUserRepo _userRepository;

    public GetTxQueryHandler(
        ITxRepo transactionRepository,
        IUserRepo userRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
    }

    public async Task<GetTxResult> Handle(
        GetTxQuery request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Check if user exists
        if (_userRepository.GetUserById(request.UserId) is not User user)
        {
            throw new HttpRequestException("Sowwy");
        }
        
        // Convert transaction types to Enums
        var types = request.Types
            .Select(t => (TransactionType)Enum.Parse(typeof(TransactionType), t, true))
            .ToList();
        
        // Get Transactions
        var transactions = _transactionRepository.GetTxByUserId(
            user.Id.Value,
            types
        );

        return new GetTxResult
        {
            UserId = user.Id.Value,
            Transactions = transactions
        };
    }
}