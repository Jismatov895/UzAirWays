using ToshiChilonzor.Domain.Entities;
using UzAirWays.DataAccess.Repositories.Flights;
using UzAirWays.Service.Mappers;

namespace UzAirWays.Service.Services.Flights;
public class FLightService : IFLightService
{
    private readonly IFlightRepository flightRepository;
    public FLightService(IFlightRepository flightRepository)
    {
        this.flightRepository = flightRepository;
    }

    public async Task<FlightViewModel> CreateAsync(FlightCreateModel model)
    {
        var existFlight = (await flightRepository.SelectAllAsQuerableAsync())
            .FirstOrDefault(flight => flight.PlaneId == model.PlaneId
            && flight.StartDate == model.StartDate
            && flight.EndDate == model.EndDate
            && flight.FirstAirportId == model.FirstAirportId
            && flight.LastAirportId == model.LastAirportId
            && !flight.IsDeleted);
        if (existFlight is not null)
            throw new Exception($"Flight is already exist with this parameters:  {model.PlaneId} Plane Id, {model.FirstAirportId} First Airport, {model.LastAirportId} Last Airport," +
                $"{model.StartDate} Start Date, {model.EndDate} End Date");

        var flight = Mapper.Map(model);
        flight.CreatedAt = DateTime.UtcNow;
        var createdFlight = await flightRepository.InsertAsync(flight);
        await flightRepository.SaveAsync();

        return Mapper.Map(createdFlight);
    }

    public async Task<FlightViewModel> UpdateAsync(long id, FlightUpdateModel model)
    {
        var existFlight = await flightRepository.SelectAsync(id)
            ?? throw new Exception($"Flight is not found with this id: {id}");

        existFlight.PlaneId = model.PlaneId;
        existFlight.FirstAirportId = model.FirstAirportId;
        existFlight.LastAirportId = model.LastAirportId;
        existFlight.EconomPrice = model.EconomPrice;
        existFlight.BusinessPrice = model.BusinessPrice;
        existFlight.StartDate = model.StartDate;
        existFlight.EndDate = model.EndDate;
        existFlight.UpdatedAt = DateTime.UtcNow;

        var updatedFlight = await flightRepository.UpdateAsync(existFlight);
        await flightRepository.SaveAsync();

        return Mapper.Map(updatedFlight);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existFlight = await flightRepository.SelectAsync(id)
           ?? throw new Exception($"Flight is not found with this Id {id}");

        existFlight.DeletedAt = DateTime.UtcNow;
        await flightRepository.DeleteAsync(existFlight);
        await flightRepository.SaveAsync();

        return true;
    }

    public async Task<FlightViewModel> GetByIdAsync(long id)
    {
        var existFlight = await flightRepository.SelectAsync(id, includes: ["Plane", "FirstAirport", "LastAirport", "Tickets"])
           ?? throw new Exception($"Flight is not found with this Id {id}");

        return Mapper.Map(existFlight);
    }

    public async Task<IEnumerable<FlightViewModel>> GetAllAsync()
    {
        var flights = await flightRepository.SelectAllAsEnumerableAsync();
        return Mapper.Map(flights);
    }
}
