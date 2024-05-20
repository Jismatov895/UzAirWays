using UzAirWays.DataAccess.Repositories.Airports;
using UzAirWays.Service.DTOs.Airports;
using UzAirWays.Service.Mappers;

namespace UzAirWays.Service.Services.Airports
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository airportRepository;
        public AirportService(IAirportRepository airportRepository)
        {
            this.airportRepository = airportRepository;
        }

        public async Task<AirportViewModel> CreateAsync(AirportCreateModel model)
        {
            var existAirport = (await airportRepository.SelectAllAsQuerableAsync()).FirstOrDefault(airport => airport.Address == model.Address && !airport.IsDeleted);
            if (existAirport is not null)
                throw new Exception($"Airport is already exist with this name {model.Name}");

            var airport = Mapper.Map(model);
            var createdAirport = await airportRepository.InsertAsync(airport);
            await airportRepository.SaveAsync();

            return Mapper.Map(createdAirport);
        }

        public async Task<AirportViewModel> UpdateAsync(long id, AirportUpdateModel model)
        {
            var existAirport = await airportRepository.SelectAsync(id)
                ?? throw new Exception($"Airport is not found with this id: {id}");

            existAirport.Name = model.Name;
            existAirport.Address = model.Address;
            existAirport.City = model.City;
            existAirport.Country = model.Country;
            existAirport.UpdatedAt = DateTime.UtcNow;

            var updatedAirport = await airportRepository.UpdateAsync(existAirport);
            await airportRepository.SaveAsync();

            return Mapper.Map(updatedAirport);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existAirport = await airportRepository.SelectAsync(id)
               ?? throw new Exception($"Airport is not found with this Id {id}");

            existAirport.DeletedAt = DateTime.UtcNow;
            await airportRepository.DeleteAsync(existAirport);
            await airportRepository.SaveAsync();

            return true;
        }

        public async Task<AirportViewModel> GetByIdAsync(long id)
        {
            var existAirport = await airportRepository.SelectAsync(id)
               ?? throw new Exception($"Airport is not found with this Id {id}");

            return Mapper.Map(existAirport);
        }

        public async Task<IEnumerable<AirportViewModel>> GetAllAsync()
        {
            var airports = await airportRepository.SelectAllAsEnumerableAsync();
            return Mapper.Map(airports);
        }
    }
}
