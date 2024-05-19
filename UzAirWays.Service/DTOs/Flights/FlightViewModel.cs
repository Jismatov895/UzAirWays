
using UzAirWays.Service.DTOs.Airports;
using UzAirWays.Service.DTOs.Planes;
using UzAirWays.Service.DTOs.Tickets;

namespace ToshiChilonzor.Domain.Entities;

public class FlightViewModel
{
    public long Id { get; set; }
    public PlaneViewModel Plane { get; set; }
    public AirportViewModel FirstAirport { get; set; }
    public AirportViewModel LastAirport { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EconomPrice { get; set; }
    public decimal BusinessPrice { get; set; }
    public IEnumerable<TicketViewModel> Tickets { get; set; }
}
