using Microsoft.Extensions.DependencyInjection;
using Application.Auth.Commands.Register;
using Application.Auth.Behaviors;
using Application.Auth.Results;
using System.Reflection;
using FluentValidation;
using MediatR;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {   
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
            typeof(DependencyInjection).Assembly));
        
        services.AddScoped<
            IPipelineBehavior<RegisterCommand, AuthRegResult>,
            RegisterValidationCommandBehaviour>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}