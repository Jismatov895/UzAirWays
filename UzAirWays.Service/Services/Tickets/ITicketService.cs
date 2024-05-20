using UzAirWays.Service.DTOs.Tickets;
using UzAirWays.Service.DTOs.Users;

namespace UzAirWays.Service.Services.Tickets;

public interface ITicketService
{
    Task<TicketViewModel> CreateAsync(TicketCreateModel model);
    Task<TicketViewModel> UpdateAsync(long id, TicketUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<TicketViewModel> GetByIdAsync(long id);
    Task<IEnumerable<TicketViewModel>> GetAllAsync();
}
