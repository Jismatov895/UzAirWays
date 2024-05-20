using UzAirWays.Service.DTOs.Airports;

namespace UzAirWays.Service.Services.Airports
{
    public interface IAirportService
    {
        Task<AirportViewModel> CreateAsync(AirportCreateModel model);
        Task<AirportViewModel> UpdateAsync(long id, AirportUpdateModel model);
        Task<bool> DeleteAsync(long id);
        Task<AirportViewModel> GetByIdAsync(long id);
        Task<IEnumerable<AirportViewModel>> GetAllAsync();
    }
}
