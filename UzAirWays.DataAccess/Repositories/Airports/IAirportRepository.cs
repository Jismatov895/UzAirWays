using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Airports;

public interface IAirportRepository
{
    Task<Airport> InsertAsync(Airport airport);
    Task<Airport> UpdateAsync(Airport airport);
    Task<Airport> DeleteAsync(Airport airport);
    Task<Airport> SelectAsync(long id);
    Task<IEnumerable<Airport>> SelectAllAsEnumerableAsync();
    Task<IQueryable<Airport>> SelectAllAsQuerableAsync();
    Task<bool> SaveAsync();
}
