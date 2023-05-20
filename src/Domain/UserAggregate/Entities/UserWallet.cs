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

    public bool UpdateBalance(decimal amount, TransactionType type){
        if (amount < 0){
            return false;
        }
        if(type == TransactionType.Deposit){
            Balance += amount;
            return true;
        }
        else if(type == TransactionType.Stake){
            if (amount > Balance){
                return false;
            }
            Balance -= amount;
            return true;
        }
        else if(type == TransactionType.Win){
            Balance += amount;
            return true;
        }
        else{
            return false;
        }
    }
    
    public decimal GetBalance(){
        return Balance;
    }
}