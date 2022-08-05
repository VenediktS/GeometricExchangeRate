using DistanceBetweenAirportsApi.Middleware;
using GeometricExchangeRate.Startup.Aplication;
using GeometricExchangeRate.Startup.Common;
using GeometricExchangeRate.Startup.Infrastructure;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureDependencies();
builder.Services.AddCommonDependencies();
builder.Services.AddApplicationDependencies();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Services.AddLogging(loggingBuilder =>
          loggingBuilder.AddSerilog(dispose: true));



var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; ;
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
