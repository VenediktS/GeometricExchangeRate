using Microsoft.Extensions.Configuration;

namespace Common.Helpers.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public ConfigurationModel Configuration { get; private set; }
        public ConfigurationProvider(IConfiguration configuration) 
        {
            Configuration = new ConfigurationModel()
            {
                CBRAPI = configuration.GetConnectionString("CBRAPI"),
                CircleRadius = configuration.GetSection("CircleRadius").Get<double>(),
                ForeignCurrencyCode = configuration.GetSection("ForeignCurrencyCode").Get<string>(),
            };
        }
    }
}
