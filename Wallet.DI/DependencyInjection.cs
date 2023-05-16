using Wallet.Application.Common.Interfaces.Persistence;
using Wallet.Application.Common.Interfaces.Services;
using Wallet.Application.Common.Interfaces.Auth;
using Microsoft.Extensions.DependencyInjection;
using Wallets.Infrastucture.Persistence;
using Wallet.Application.Services.Auth;
using Wallet.Infrastructure.Auth;


namespace Wallet.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {   
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGen>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepo, UserRepo>();

        return services;
    }
} 