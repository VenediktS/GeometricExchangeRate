using Domain.Models;

namespace ExternalApiProvider.CBR
{
    public interface ICBRCurrencyRateService
    {
         Task<CurrencyRate> GetRate(DateTime dateTime);
    }
}
