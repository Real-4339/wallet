using Domain.Transactions.ValueObjects;
using Domain.Common.Primitives;
using Domain.User.ValueObjects;

namespace Domain.User.Entities;

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
        UserWalletId id,
        decimal balance) =>
        new(id, balance);

    public void AddTransaction(TxId txId){
        _transactionIds.Add(txId);
    }

    public void UpdateBalance(decimal amount, string type){
        if (amount < 0){
            throw new Exception("Amount cannot be negative");
        }
        if(type == "deposit"){
            Balance += amount;
        }
        else if(type == "stake"){
            if (amount > Balance){
                throw new Exception("Insufficient funds");
            }
            Balance -= amount;
        }
        else if(type == "win"){
            Balance += amount;
        }
        else if(type == "lose"){
            Balance -= amount;
        }
        else{
            throw new Exception("Invalid transaction type");
        }
    }
}