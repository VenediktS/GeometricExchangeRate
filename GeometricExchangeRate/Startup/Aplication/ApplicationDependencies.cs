using Aplication.Interfaces;
using Aplication.Services;

namespace GeometricExchangeRate.Startup.Aplication
{
    public static class ApplicationDependencies
    {
        public static void AddApplicationDependencies(this IServiceCollection service) 
        {
            service.AddScoped<IExchangeRateService, ExchangeRateService> ();
        }
    }
}
