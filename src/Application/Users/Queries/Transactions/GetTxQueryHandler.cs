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
        // Check if user exists
        if (await _userRepository.GetUserByIdAsync(request.UserId) is not User user)
        {
            throw new HttpRequestException("Sowwy");
        }
        
        // Convert transaction types to Enums
        var types = request.Types
            .Select(t => (TransactionType)Enum.Parse(typeof(TransactionType), t, true))
            .ToList();
        
        // Get Transactions
        var transactions = await _transactionRepository.GetTxByUserIdAsync(
            user.Id.Value,
            types
        );

        var serializedTransactions = transactions
                .Select(t => t.Serialize()).ToList();

        return new GetTxResult(
            user.Id.Value,
            serializedTransactions);
    }
}