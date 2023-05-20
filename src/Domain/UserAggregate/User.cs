using Domain.TransactionsAggregate.ValueObjects;
using Domain.TransactionsAggregate.Enums;
using Domain.UserAggregate.ValueObjects;
using Domain.UserAggregate.Entities;
using Domain.Common.Primitives;

namespace Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string firstName { get; private set; }
    public string lastName { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public UserWallet Wallet { get; private set; } = default!;

    private User(
        UserId userId,
        string firstname,
        string lastname,
        string email,
        string username,
        string password)
        : base(userId)
    {
        firstName = firstname;
        lastName = lastname;
        Email = email;
        Username = username;
        Password = password;
    }

    public static User Create(
        string firstname,
        string lastname,
        string email,
        string username,
        string password) =>
        new(
            UserId.New(),
            firstname,
            lastname,
            email,
            username,
            password);
        
    public void RegisterWallet(decimal balance){
        if (Wallet != null){
            throw new Exception("User already has a wallet");
        }
        Wallet = UserWallet.Create(balance);
    }

    public decimal GetBalance(){
        if (Wallet == null){
            throw new Exception("User does not have a wallet");
        }
        return Wallet.GetBalance();
    }

    public bool AddTransaction(TxId txId, decimal amount, TransactionType type){
        if (Wallet == null){
            throw new Exception("User does not have a wallet");
        }
        Wallet.AddTransaction(txId);
        var res = Wallet.UpdateBalance(amount, type);
        return res;
    }

}