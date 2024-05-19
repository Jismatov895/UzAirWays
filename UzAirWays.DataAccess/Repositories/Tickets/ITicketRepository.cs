using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Tickets;

public interface ITicketRepository
{
    Task<Ticket> InsertAsync(Ticket ticket);
    Task<Ticket> UpdateAsync(Ticket ticket);
    Task<Ticket> DeleteAsync(Ticket ticket);
    Task<Ticket> SelectAsync(long id, string[] includes = null);
    Task<IEnumerable<Ticket>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true);
    Task<IQueryable<Ticket>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true);
    Task<bool> SaveAsync();
}
