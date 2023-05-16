using Wallet.Application.Common.Interfaces.Persistence;
using Wallet.Application.Common.Interfaces.Services;
using Wallet.Application.Common.Interfaces.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Wallet.Infrastucture.Persistence;
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
        ConfigurationManager configuration)
    {   
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddScoped<IJwtTokenGenerator, JwtTokenGen>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        
        services.AddSingleton<IUserRepo, UserRepo>();

        return services;
    }
} 