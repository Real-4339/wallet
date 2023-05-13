using System;

namespace Wallet.Contracts.Authentication;

public record AuthenticationResponse(
    Guid id,
    string first_name,
    string last_name,
    string email,
    string token);