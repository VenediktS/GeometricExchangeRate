using Aplication.Interfaces;
using Common.GeometricDate;
using Common.GeometricDate.Services.Cartesian;
using Domain.Models;
using ExternalApiProvider.CBR;

namespace Aplication.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly ICBRCurrencyRateService _cbrService;
        private readonly IGeometricDate<CartesianCoordinates> _dateService;
        public ExchangeRateService(ICBRCurrencyRateService cbrService, IGeometricDate<CartesianCoordinates> dateService ) 
        {
            _cbrService = cbrService;
            _dateService = dateService;
        }
        public async Task<CurrencyRate> Get(double x, double y) 
        {
            var date = _dateService.GetDate(new CartesianCoordinates() { X = x, Y = y });

            return await _cbrService.GetRate(date);
        }

    }
}
