using Common.Exceptions;
using Common.Helpers.Configuration;
using Domain.Models;
using ExternalApiProvider.CBR.Models;
using System.Net;
using System.Xml.Serialization;

namespace ExternalApiProvider.CBR
{
    public class CBRCurrencyRateService : ICBRCurrencyRateService
    {
        private readonly IMyConfigurationProvider _;
        public CBRCurrencyRateService(IMyConfigurationProvider configuration)
        {
            _ = configuration;
        }
        public async Task<CurrencyRate> GetRate(DateTime dateTime)
        {
            var curs = await Request(dateTime);

            if (curs == null) 
            {
                throw new BadRequestToExternalSystemException("Ошибка при выполнении запроса ко внешнему ресурсу");
            }

            var rate = curs.Valutes.FirstOrDefault(el => el.CharCode == _.Configuration.ForeignCurrencyCode);

            if (rate == null) 
            {
                throw new NotFoundCurencyRateException($"Курс валюты с кодом {_.Configuration.ForeignCurrencyCode} - не найден");
            }

            return new CurrencyRate() { Rate  = rate.Value };
        }

        private async Task<ValCurs> Request(DateTime dateTime)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create($"{_.Configuration.CBRAPI}?date_req={dateTime.ToShortDateString().Replace('.', '/')}");
            httpRequest.ContentType = "text/xml";

            var httpResponse = (HttpWebResponse)(await httpRequest.GetResponseAsync());

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new BadRequestToExternalSystemException("Ошибка при выполнении запроса ко внешнему ресурсу");
            }

            ValCurs curs;

            XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                curs = (ValCurs)serializer.Deserialize(streamReader);
            }

            return curs;
        }
    
    }
}
