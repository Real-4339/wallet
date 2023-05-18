using Microsoft.AspNetCore.Mvc.Infrastructure;
using Api.Mapping;
using Api.Errors;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {   

        services.AddControllers();
        //services.AddSingleton<ProblemDetailsFactory, ErrorFactory>();
        services.AddEndpointsApiExplorer();
        services.AddMappings();

        return services;
    }
}