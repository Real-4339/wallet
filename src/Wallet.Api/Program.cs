using Wallet.Api.Middleware;
using Wallet.DI;

var builder = WebApplication.CreateBuilder(args);
{   
    // Add services to the container.
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{   
    app.UseMiddleware<ErrorHandler>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}