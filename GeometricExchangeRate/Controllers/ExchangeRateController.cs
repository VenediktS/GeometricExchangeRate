using Aplication.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeometricExchangeRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Exchange Rate API")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _service;
        public ExchangeRateController(IExchangeRateService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<CurrencyRate>> Get([FromQuery] double x, [FromQuery] double y) 
        {
            return Ok(await _service.Get(x, y));
        }
    }
}
