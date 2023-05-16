# Domain Models

## User

```json
{
    "id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "firstName" : "John",
    "lastName" : "Doe",
    "Email" : "myemail@mail.com",
    "Username" : "johndoe",
    "Password" : "password"
}
```

## Wallet

```json
{
    "id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "player_id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "balance" : 1000
}
```

## Transaction

```json
{
    "id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "player_id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "transaction_id" : "transaction-guid",
    "transaction_type" : "deposit",
    "amount" : 100
}
```