
namespace Common.GeometricDate
{
    public interface IGeometricDate<T> where T : Coordinates
    {
        DateTime GetDate(T coordinates);
    }
}
