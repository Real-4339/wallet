using Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Infrastucture.Persistence;
using Infrastructure.Auth;

namespace Infrastructure;

public static class DependencyInjection
{
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