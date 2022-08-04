
namespace Common.Exceptions
{
    public class OutOfCircleExeption : Exception
    {
        public OutOfCircleExeption(string message) : base(message)
        {
        }

        public OutOfCircleExeption(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
