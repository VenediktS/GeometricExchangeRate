using Common.Exceptions;
using Common.Helpers.Configuration;

namespace Common.GeometricDate.Services.Cartesian
{
    public class CartesianDate : IGeometricDate<CartesianCoordinates>
    {
        private readonly IConfigurationProvider _;
        public CartesianDate(IConfigurationProvider configuration)
        {
            _ = configuration;
        }

        public DateTime GetDate(CartesianCoordinates coordinates)
        {
            if (!InСircle(coordinates))
                 throw new OutOfCircleExeption("Координаты за пределами круга");

            return GetDateByPartOfCircle(coordinates);
        }

        private bool InСircle(CartesianCoordinates coordinates) 
        {
            return Math.Sqrt(coordinates.X) + Math.Sqrt(coordinates.Y) <= Math.Sqrt(_.Configuration.CircleRadius);
        }

        private DateTime GetDateByPartOfCircle(CartesianCoordinates coordinates) 
        {
            var result = DateTime.Today;

            if (coordinates.X >= 0 && coordinates.Y >= 0)
                result = DateTime.Today;

            else if (coordinates.X <= 0 && coordinates.Y >= 0)
                result = DateTime.Now.AddDays(-1);

            else if (coordinates.X >= 0 && coordinates.Y <= 0)
                result = DateTime.Now.AddDays(+1);

            else if (coordinates.X <= 0 && coordinates.Y <= 0)
                result = DateTime.Now.AddDays(-2);

            return result;
        }
    }
}
