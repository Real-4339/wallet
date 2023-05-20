using Infrastructure;
using Api.Middleware;
using Application;

var builder = WebApplication.CreateBuilder(args);
{   
    // Add services to the container.
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{   
    app.UseMiddleware<ErrorHandler>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}