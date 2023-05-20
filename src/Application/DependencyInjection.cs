using Microsoft.Extensions.DependencyInjection;
using Application.Users.Commands.Transactions;
using Application.Users.Queries.Transactions;
using Application.Auth.Commands.Register;
using Application.Auth.Behaviors;
using Application.Common.Results;
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
        
        services.AddScoped<
            IPipelineBehavior<CreditTxCommand, StatusResult>,
            TransactionBehavior>();

        services.AddScoped<
            IPipelineBehavior<GetTxQuery, GetTxResult>,
            GetTxBehavior>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}