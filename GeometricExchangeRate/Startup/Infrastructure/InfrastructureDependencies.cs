using ExternalApiProvider.CBR;

namespace GeometricExchangeRate.Startup.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static void AddInfrastructureDependencies(this IServiceCollection service) 
        {
            service.AddScoped<ICBRCurrencyRateService, CBRCurrencyRateService>();
        }
    }
}
