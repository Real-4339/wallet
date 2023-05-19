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

```json
{
    "Id" : { "value" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a" },
    "FirstName" : "John",
    "LastName" : "Doe",
    "Email" : "myemail@mail.com",
    "Username" : "johndoe",
    "Password" : "password-hash",
    "Wallet" : {
        "Balance" : 1000,
        "Transactions" : [
            {
                "Id" : { "value" : "transaction-guid" },
                "Type" : "deposit",
                "Amount" : 100
            }
        ]
    }
}
```

## Transaction

```csharp
class Tx {
    Tx Create();
    void Commit();
    // TODO: Add remaining methods
}
```

```json
{
    "Id" : {"value" : "transaction-guid"},
    "PlayerId" : {"value" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a"},
    "Type" : "deposit",
    "Amount" : 100
}
```