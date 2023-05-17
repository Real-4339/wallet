using Microsoft.Extensions.DependencyInjection;
using Application.Auth.Commands.Register;
using Application.Common.Behaviors;
using Application.Auth.Common;
using System.Reflection;
using FluentValidation;
using MediatR;
using OneOf;

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