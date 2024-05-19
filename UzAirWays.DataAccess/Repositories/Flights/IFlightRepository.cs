using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Flights;

public interface IFlightRepository
{
    Task<Flight> InsertAsync(Flight flight);
    Task<Flight> UpdateAsync(Flight flight);
    Task<Flight> DeleteAsync(Flight flight);
    Task<Flight> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<Flight>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
    Task<IQueryable<Flight>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
    Task<bool> SaveAsync();
}
