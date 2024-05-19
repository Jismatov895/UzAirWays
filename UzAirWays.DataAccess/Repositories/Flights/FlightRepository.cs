using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Flights;

public class FlightRepository : IFlightRepository
{
    private AppDbContext context;
    public FlightRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Flight> InsertAsync(Flight flight)
    {
        return (await context.Flights.AddAsync(flight)).Entity;
    }

    public async Task<Flight> UpdateAsync(Flight flight)
    {
        context.Flights.Update(flight);
        return await Task.FromResult(flight);
    }

    public async Task<Flight> DeleteAsync(Flight flight)
    {
        flight.IsDeleted = true;
        context.Flights.Update(flight);
        return await Task.FromResult(flight);
    }

    public async Task<Flight> SelectAsync(long id, string[] includes = null)
    {
        var flights = context.Flights;
        if (includes is not null)
            foreach (var include in includes)
                flights.Include(include);

        var flight = await flights.Where(flight => !flight.IsDeleted && flight.Id == id).FirstOrDefaultAsync();
        return flight;
    }

    public async Task<IEnumerable<Flight>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true)
    {
        var flights = context.Flights;
        if (includes is not null)
            foreach (var include in includes)
                flights.Include(include);

        if (!isTraking)
            flights.AsNoTracking();

        await flights.Where(flight => !flight.IsDeleted).FirstOrDefaultAsync();

        return flights;
    }

    public async Task<IQueryable<Flight>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true)
    {
        var flights = context.Flights;
        if (includes is not null)
            foreach (var include in includes)
                flights.Include(include);

        if (!isTraking)
            flights.AsNoTracking();

        return await Task.FromResult(context.Flights.AsQueryable().Where(flight => !flight.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

}
