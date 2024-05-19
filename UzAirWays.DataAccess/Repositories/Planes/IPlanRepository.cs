using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Planes;

public interface IPlanRepository
{
    Task<Plane> InsertAsync(Plane plane);
    Task<Plane> UpdateAsync(Plane plane);
    Task<Plane> DeleteAsync(Plane plane);
    Task<Plane> SelectAsync(long id);
    Task<IEnumerable<Plane>> SelectAllAsEnumerableAsync();
    Task<IQueryable<Plane>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
