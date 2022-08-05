using System.Globalization;

namespace GeometricExchangeRate.Middleware.ApiExceptions
{
    public class ResposeException : Exception
    {
        public ResposeException() : base() { }

        public ResposeException(string message) : base(message) { }

        public ResposeException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
