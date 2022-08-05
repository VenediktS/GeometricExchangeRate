using Common.GeometricDate;
using Common.GeometricDate.Services.Cartesian;
using Common.Helpers.Configuration;

namespace GeometricExchangeRate.Startup.Common
{
    public static class CommonDependencies
    {
        public static void AddCommonDependencies(this IServiceCollection service) 
        {
            service.AddSingleton<IMyConfigurationProvider, MyConfigurationProvider>();

            service.AddScoped<IGeometricDate<CartesianCoordinates>, CartesianDate>();
        }
    }
}
