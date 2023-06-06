# Player Wallet Service

This project is a .NET Core backend service that exposes an HTTP REST API for managing player wallets. The service allows players to perform transactions and retrieve information about their wallet balance and transaction history. Authentication and authorization are based on JWT tokens.

## Functional Requirements

- Players are identified by a GUID identifier.
- Each player's wallet consists of a balance, represented as a decimal value. Currency is neglected, and all amounts are expected to be in a   single common currency (e.g., EURO).
- The wallet balance is manipulated via transactions, which are identified by a unique GUID identifier. Each transaction has a type and a decimal amount that is added or subtracted from the wallet balance.
- The possible transaction types are:
    - Deposit: Increments the balance.
    - Stake: Decrements the balance.
    - Win: Increments the balance.
- The wallet balance may never drop below 0. If a transaction would result in a negative balance, it is rejected.
- Each transaction should exhibit idempotent behavior. If a transaction is initially rejected, it should be rejected on repeat calls. If a transaction is initially accepted, subsequent repeat calls should return an "accepted" status without affecting the balance further.
- Transactions for a single player should be serializable. Concurrent transactions for the same player can be processed in any order, but they must keep the player's wallet in a consistent state.

## Non-Functional Requirements

- The service can be deployed as a single node.
- The project includes mocked in-memory implementations of the repository interfaces. There is no real persistence layer implemented.
- Optimization for heavy reads is a bonus requirement. The "get player's balance" API calls are expected to be much more frequent than the "credit transaction" calls.
- The service supports multi-node deployment for load distribution.

## API Contracts

The service provides the following API endpoints:

- POST /auth/register: Registers a new playerId, username and a JWT token. Returns an error if the player is already registered.

- POST /auth/login: Logs in a player. Returns an error if the player is not registered or the password is incorrect.

- POST /user/{userId}/wallet: Registers a new player's wallet with an initial balance of 0. Returns an error if the player's wallet is already registered.

- GET /user/{userId}/wallet/balance: Retrieves the balance of a player's wallet.

- POST /transactions/credit/{userId}: Adds a new transaction to a player's wallet. Returns whether the transaction was accepted or rejected.

- GET /user/{userId}/wallet/transactions: Retrieves a list of saved transactions for a given player, including the transaction ID, amount, type, and state.
    - Supports filtering by transaction type (accepts multiple types in a single request).

## Getting Started

To run the Player Wallet Service locally, follow these steps:

1. Clone the repository: `git clone https://github.com/Real-4339/wallet.git`

2. Navigate to the project directory: `cd wallet`

3. All commands are run using the `make` utility. To see a list of available commands, run `make help`.

4. To run the service, run `make run`. The service will be available at `http://localhost:5218`.

5. To run the tests, run `make tests`.

### Build

```make
make build
```

### Run

```make
make run
```

### Tests

```make
make tests -B
```

## Dependencies

- .NET Core 3.1 or later
- ASP.NET Core - Framework for building web applications and APIs with .NET Core
- XUnit - Testing framework for .NET Core applications

## Contributing

Contributions to the Player Wallet Service are welcome.  
If you have any bug reports, feature requests, or suggestions, please open an issue on the GitHub repository.

## License

The Player Wallet Service is licensed under the [MIT](https://github.com/Real-4339/wallet/blob/main/LICENSE) license.

![GitHub](https://img.shields.io/github/license/Real-4339/wallet?style=for-the-badge)
