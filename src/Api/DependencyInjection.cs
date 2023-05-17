using Api.Mapping;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {   

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddMappings();

        return services;
    }
}