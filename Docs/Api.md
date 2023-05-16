# API

- [My App API](#api)  
    - [Authentication](#authentication)  
        - [Register](#register)  
            - [Request](#request)  
            - [Response](#response)  
        - [Login](#login)  
            - [Request](#request-1)  
            - [Response](#response-1)  
    - [Register Wallet](#register-wallet)  
        - [Request](#request-2)  
        - [Response](#response-2)  
    - [Get Players Balance](#get-players-balance)  
        - [Request](#request-3)  
        - [Response](#response-3)  
    - [Credit Transaction to Player's Wallet](#credit-transaction-to-players-wallet)  
        - [Request](#request-4)  
        - [Response](#response-4)  
    - [Get Player's Transactions](#get-players-transactions)  
        - [Request](#request-5)  
        - [Response](#response-5)  

## Authentication

### Register

Registers a new user.

#### Request

```js
POST /auth/register
Content-Type: application/json
```

```json
{   
    "first_name": "first_name",
    "last_name": "last_name",
    "email": "email",
    "username": "username",
    "password": "password"
}
```

#### Response

Successful Registration
```js
HTTP/1.1 201 Created
Content-Type: application/json
```

```json
{   
    "id" : "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "username": "username",
    "token" : "token"
}
```

Error Response
```js
HTTP/1.1 500 Internal Server Error
Content-Type: application/json
```

```json
{   
    "error": {
        "code": 500,
        "message": "Internal Server Error"
    }
}
```

### Login

Logs in a user.

#### Request

```js
POST /auth/login
Content-Type: application/json
```

```json
{   
    "username": "username",
    "password": "password"
}
```

#### Response

Successful Login
```js
HTTP/1.1 200 OK
```

```json
{
    "status": "success"
}
```

Error Response
```js
HTTP/1.1 401 Unauthorized
Content-Type: application/json
```

```json
{   
    "error": {
        "code": 401,
        "message": "Unauthorized"
    }
}
```

## Register Wallet

Registers a new wallet for a player.

### Request

```js
POST /register_wallet
Content-Type: application/json
```

```json
{   
    "player_id": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a"
}
```

### Response

Successful Registration
```js
HTTP/1.1 201 Created
Content-Type: application/json
```

```json
{   
    "status": "success"
}
```
Error Response
```js
HTTP/1.1 500 Internal Server Error
Content-Type: application/json
```

```json
{   
    "error": {
        "code": 500,
        "message": "Internal Server Error"
    }
}
```

## Get Players Balance

Gets the balance of a player.

### Request

```js
GET /get_players_balance/:player_id
```

### Response

Successful Response
```js
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{   
    "player_id": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "balance": 100
}
```

## Credit Transaction to Player's Wallet

Credits a transaction to a player's wallet.

### Request

```js
POST /credit_transaction
Content-Type: application/json
```

```json
{   
    "player_id": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "transaction_type": "deposit",
    "amount": 100
}
```

### Response

Successful Response
```js
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{   
    "player_id": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "transaction_id": "transaction-guid",
    "transaction_type": "deposit",
    "amount": 100,
    "balance": 200
}
```

Error Response
```js
HTTP/1.1 400 Bad Request
Content-Type: application/json
```

```json
{   
    "error": {
        "code": 400,
        "message": "Bad Request"
    }
}
```

## Get Player's Transactions

Retrieves a list of saved transactions for a given player, with optional filtering by transaction type.

### Request

```js
GET /player_transactions/{player_id}?types=deposit,stake
```

### Response

Successful Response
```js
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{   
    "player_id": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "transactions": [
        {
            "transaction_id": "transaction-guid1",
            "transaction_type": "deposit",
            "amount": 100,
            "state": "completed"
        },
        {
            "transaction_id": "transaction-guid2",
            "transaction_type": "stake",
            "amount": 50,
            "state": "completed"
        }
    ]
}
```

Error Response
```js
HTTP/1.1 404 Not Found
Content-Type: application/json
```

```json
{   
    "error": {
        "code": 404,
        "message": "Player not found"
    }
}
```