using ToshiChilonzor.Domain.Entities;

namespace UzAirWays.Service.Services.Flights;
public interface IFLightService
{
    Task<FlightViewModel> CreateAsync(FlightCreateModel model);
    Task<FlightViewModel> UpdateAsync(long id, FlightUpdateModel model);
    Task<bool> DeleteAsync(long id);
    Task<FlightViewModel> GetByIdAsync(long id);
    Task<IEnumerable<FlightViewModel>> GetAllAsync();
}
