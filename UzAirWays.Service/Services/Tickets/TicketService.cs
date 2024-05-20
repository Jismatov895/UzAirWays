using UzAirWays.DataAccess.Repositories.Tickets;
using UzAirWays.Service.DTOs.Tickets;
using UzAirWays.Service.Mappers;

namespace UzAirWays.Service.Services.Tickets;
public class TicketService : ITicketService
{

    private readonly ITicketRepository ticketRepository;
    public TicketService(ITicketRepository ticketRepository)
    {
        this.ticketRepository = ticketRepository;
    }

    public async Task<TicketViewModel> CreateAsync(TicketCreateModel model)
    {
        var existFlight = (await ticketRepository.SelectAllAsQuerableAsync()).FirstOrDefault(ticket => ticket.UserId == model.UserId && ticket.FlightId == model.FlightId && !ticket.IsDeleted);
        if (existFlight is not null)
            throw new Exception($"Ticket is already exist in User from Id {model.UserId} to Flight Id {model.FlightId}");

        var ticket = Mapper.Map(model);
        var createdUser = await ticketRepository.InsertAsync(ticket);
        await ticketRepository.SaveAsync();

        return Mapper.Map(createdUser);
    }

    public async Task<TicketViewModel> UpdateAsync(long id, TicketUpdateModel model)
    {
        var existTicket = await ticketRepository.SelectAsync(id)
            ?? throw new Exception($"Ticket is not found with this id: {id}");

        existTicket.SeedStatus = model.SeedStatus;
        existTicket.Price = model.Price;
        existTicket.FlightId = model.FlightId;
        existTicket.UserId = model.UserId;
        existTicket.UpdatedAt = DateTime.UtcNow;

        var updatedTicket = await ticketRepository.UpdateAsync(existTicket);
        await ticketRepository.SaveAsync();

        return Mapper.Map(updatedTicket);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existTicket = await ticketRepository.SelectAsync(id)
           ?? throw new Exception($"Ticket is not found with this Id {id}");

        existTicket.DeletedAt = DateTime.UtcNow;
        await ticketRepository.DeleteAsync(existTicket);
        await ticketRepository.SaveAsync();

        return true;
    }

    public async Task<TicketViewModel> GetByIdAsync(long id)
    {
        var existTicket = await ticketRepository.SelectAsync(id, includes: ["User", "Flight"])
           ?? throw new Exception($"Ticket is not found with this Id {id}");

        return Mapper.Map(existTicket);
    }

    public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
    {
        var tickets = await ticketRepository.SelectAllAsEnumerableAsync();
        return Mapper.Map(tickets);
    }
}
