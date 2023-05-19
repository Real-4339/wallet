# Domain Models

## User

```csharp
class User {
    User Create();
    void CreateWallet();
    void Update();
    void UpdateWallet();
    void Delete();
}
```

```csharp
class Wallet {
    Wallet Create();
    void UpdateBalance();
    void AddTransaction();
}
```

> Wallet is an Entity, User is an Aggregate Root

```json
{
    "Id" : { "value" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a" },
    "FirstName" : "John",
    "LastName" : "Doe",
    "Email" : "myemail@mail.com",
    "Username" : "johndoe",
    "Password" : "password-hash",
    "Wallet" : {
        "Id" : { "value" : "wallet-guid" },
        "Balance" : 1000,
        "Txs" : [
            {
                {"value" : "transaction-guid"},
            }
        ]
    }
}
```

## Transaction

```csharp
class Tx {
    Tx Create();
}
```

> Tx types: deposit, stake, win

```json
{
    "Id" : {"value" : "transaction-guid"},
    "UserId" : {"value" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a"},
    "Type" : "deposit",
    "Amount" : 100
}
```