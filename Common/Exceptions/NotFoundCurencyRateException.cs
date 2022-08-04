
namespace Common.Exceptions
{
    public class NotFoundCurencyRateException : Exception
    {
        public NotFoundCurencyRateException(string message) : base(message)
        {
        }

        public NotFoundCurencyRateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}