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
    - [Get User's Balance](#get-users-balance)  
        - [Request](#request-3)  
        - [Response](#response-3)  
    - [Credit Transaction to User's Wallet](#credit-transaction-to-users-wallet)  
        - [Request](#request-4)  
        - [Response](#response-4)  
    - [Get User's Transactions](#get-users-transactions)  
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
    "firstName": "firstName",
    "lastName": "lastName",
    "Email": "email",
    "Username": "username",
    "Password": "password-hash"
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
    "password": "password-hash"
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

Registers a new wallet for a user.

### Request

```js
POST /user/{userId}/wallet
Content-Type: application/json
Authorization: Bearer {{token}}
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

## Get Users Balance

Gets the balance of a user.

### Request

```js
GET /user/{userId}/wallet/balance
Authorization: Bearer {{token}}
```

### Response

Successful Response
```js
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{   
    "userId": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "balance": 100
}
```

## Credit Transaction to User's Wallet

Credits a transaction to a user's wallet.

### Request

```js
POST /transactions/credit/{userId}
Content-Type: application/json
Authorization: Bearer {{token}}
```
> Note: The transaction type can be `deposit`, `stake` or `win`.  
  Transaction-guid is optional

```json
{   
    "Id": "transaction-guid",
    "transactionType": "deposit",
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
    "status": "accepted/rejected"
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

## Get User's Transactions

Retrieves a list of saved transactions for a given user, with optional filtering by transaction type.

### Request

```js
GET /user/{userId}/wallet/transactions?transactionType={transactionType}
Authorization: Bearer {{token}}
```

### Response

Successful Response
```js
HTTP/1.1 200 OK
Content-Type: application/json
```

```json
{   
    "userId": "d89f4a1e-9c5b-4e4a-8c0e-0e8a5a1a1a1a",
    "transactions": [
        {
            "Id": "transaction-guid1",
            "amount": 100,
            "transactionType": "deposit",
            "transactionState": "completed"
        },
        {
            "Id": "transaction-guid2",
            "amount": 50,
            "transactionType": "stake",
            "transactionState": "completed"
        }
    ]
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