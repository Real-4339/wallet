using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastucture.Persistence;
using Infrastructure.Auth;

namespace DI;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {   
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(
            Application.Auth.Commands.Register.RegisterCommandHandler).Assembly, 
            typeof(Application.Auth.Queries.Login.LoginQueryHandler).Assembly,
            typeof(Application.Auth.Common.AuthLogResult).Assembly,
            typeof(Application.Auth.Common.AuthRegResult).Assembly));
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