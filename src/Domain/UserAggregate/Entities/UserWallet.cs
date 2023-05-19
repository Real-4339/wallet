using Domain.TransactionsAggregate.ValueObjects;
using Domain.TransactionsAggregate.Enums;
using Domain.UserAggregate.ValueObjects;
using Domain.Common.Primitives;

namespace Domain.UserAggregate.Entities;

public sealed class UserWallet : Entity<UserWalletId>
{   
    private readonly List<TxId> _transactionIds = new();
    public decimal Balance { get; private set;}
    
    private UserWallet(
        UserWalletId id,
        decimal balance)
        : base(id)
    {
        Balance = balance;
    }

    public IReadOnlyList<TxId> TransactionIds => _transactionIds.ToList();

    public static UserWallet Create(
        decimal balance) =>
        new(
            UserWalletId.New(),
            balance);

    public void AddTransaction(TxId txId){
        _transactionIds.Add(txId);
    }

    public void UpdateBalance(decimal amount, TransactionType type){
        if (amount < 0){
            throw new Exception("Amount cannot be negative");
        }
        if(type == TransactionType.Deposit){
            Balance += amount;
        }
        else if(type == TransactionType.Stake){
            if (amount > Balance){
                throw new Exception("Insufficient funds");
            }
            Balance -= amount;
        }
        else if(type == TransactionType.Win){
            Balance += amount;
        }
        else{
            throw new Exception("Invalid transaction type");
        }
    }
    
    public decimal GetBalance(){
        return Balance;
    }
}