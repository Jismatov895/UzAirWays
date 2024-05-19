using UzAirWays.Domain.Enums;

namespace UzAirWays.Service.DTOs.Tickets;
public class TicketCreateModel
{
    public long FlightId { get; set; }
    public long UserId { get; set; }
    public SeedStatus SeedStatus { get; set; }
    public decimal Price { get; set; }
}

