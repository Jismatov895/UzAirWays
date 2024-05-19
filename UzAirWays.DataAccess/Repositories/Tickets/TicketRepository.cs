using Microsoft.EntityFrameworkCore;
using UzAirWays.Domain.Entities;

namespace UzAirWays.DataAccess.Repositories.Tickets;

public class TicketRepository : ITicketRepository
{
    private AppDbContext context;
    public TicketRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Ticket> InsertAsync(Ticket ticket)
    {
        return (await context.Tickets.AddAsync(ticket)).Entity;
    }

    public async Task<Ticket> UpdateAsync(Ticket ticket)
    {
        context.Tickets.Update(ticket);
        return await Task.FromResult(ticket);
    }

    public async Task<Ticket> DeleteAsync(Ticket ticket)
    {
        ticket.IsDeleted = true;
        context.Tickets.Update(ticket);
        return await Task.FromResult(ticket);
    }

    public async Task<Ticket> SelectAsync(long id, string[] includes = null)
    {
        var tickets = context.Tickets;
        if (includes is not null)
            foreach (var include in includes)
                tickets.Include(include);

        var ticket = await tickets.Where(ticket => !ticket.IsDeleted && ticket.Id == id).FirstOrDefaultAsync();
        return ticket;
    }
    public async Task<IEnumerable<Ticket>> SelectAllAsEnumerableAsync(string[] includes = null, bool isTraking = true)
    {
        var tickets = context.Tickets;
        if (includes is not null)
            foreach (var include in includes)
                tickets.Include(include);

        if (!isTraking)
            tickets.AsNoTracking();

        var ticket = await Task.FromResult(context.Tickets.Where(ticket => !ticket.IsDeleted));
        return ticket;
    }

    public async Task<IQueryable<Ticket>> SelectAllAsQuerableAsync(string[] includes = null, bool isTraking = true)
    {
        var tickets = context.Tickets;
        if (includes is not null)
            foreach (var include in includes)
                tickets.Include(include);

        if (!isTraking)
            tickets.AsNoTracking();

        return await Task.FromResult(context.Tickets.AsQueryable().Where(ticket => !ticket.IsDeleted));
    }

    public async Task<bool> SaveAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

}
