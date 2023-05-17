using Api.Middleware;
using Application;
using Infrastructure;

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
    app.MapControllers();
    app.Run();
}