
namespace Common.Exceptions
{
    public class BadRequestToExternalSystemException : Exception
    {
        public BadRequestToExternalSystemException(string message) : base(message)
        {
        }

        public BadRequestToExternalSystemException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
