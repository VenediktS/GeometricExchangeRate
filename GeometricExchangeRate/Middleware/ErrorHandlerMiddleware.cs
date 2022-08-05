using Common.Exceptions;
using GeometricExchangeRate.Middleware.ApiExceptions;
using System.Net;
using System.Text.Json;

namespace DistanceBetweenAirportsApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ResposeException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case OutOfCircleExeption e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundCurencyRateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case BadRequestToExternalSystemException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case InvalidDataException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
