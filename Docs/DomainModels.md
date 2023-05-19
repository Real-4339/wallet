# Domain Models

## User

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

```json
{
    "Id" : {"value" : "transaction-guid"},
    "PlayerId" : {"value" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a"},
    "Type" : "deposit",
    "Amount" : 100
}
```