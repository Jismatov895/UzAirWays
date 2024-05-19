using System.Numerics;
using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Airports;

public class AirportRepository : IAirportRepository
{
    private AppDbContext context;
    public AirportRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Airport> InsertAsync(Airport airport)
    {
        return (await context.Airports.AddAsync(airport)).Entity;
    }

    public async Task<Airport> UpdateAsync(Airport airport)
    {
        context.Airports.Update(airport);
        return await Task.FromResult(airport);
    }

    public async Task<Airport> DeleteAsync(Airport airport)
    {
        airport.IsDeleted = true;
        context.Airports.Update(airport);
        return await Task.FromResult(airport);
    }

    public async Task<Airport> SelectAsync(long id)
    {
        return await context.Airports.FindAsync(id);
    }

    public async Task<IEnumerable<Airport>> SelectAllAsEnumerableAsync()
    {
        return await Task.FromResult(context.Airports.Where(airport => !airport.IsDeleted));
    }

    public async Task<IQueryable<Airport>> SelectAllAsQuerableAsync()
    {
        return await Task.FromResult(context.Airports.AsQueryable().Where(airport => !airport.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

}
