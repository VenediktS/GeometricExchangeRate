using Domain.Models;

namespace Aplication.Interfaces
{
    public interface IExchangeRateService
    {
        Task<CurrencyRate> Get(double x, double y);
    }
}
