using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Common.Helpers.Configuration
{
    public class MyConfigurationProvider : IMyConfigurationProvider
    {
        public ConfigurationModel Configuration { get; private set; }
        public MyConfigurationProvider(IConfiguration configuration) 
        {
            Configuration = new ConfigurationModel()
            {
                CBRAPI = CheckOption(configuration.GetConnectionString("CBRAPI")),
                CircleRadius = CheckOption(configuration.GetSection("CircleRadius").Get<double>()),
                ForeignCurrencyCode = CheckOption(configuration.GetSection("ForeignCurrencyCode").Get<string>()),
            };
        }

        private T CheckOption<T>(T bound) 
        {
            if (bound == null)
                throw new InvalidOperationException($"Настройка с именем '{nameof(T)}' запрошена как обязательная, но не найдена в файле конфигурации.");

            return bound;
        }
    }
}
