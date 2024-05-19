using ToshiChilonzor.Domain.Entities;
using UzAirWays.Domain.Enums;
using UzAirWays.Service.DTOs.Users;

namespace UzAirWays.Service.DTOs.Tickets;

public class TicketViewModel
{
    public FlightViewModel Flight { get; set; }
    public UserViewModel User { get; set; }
    public SeedStatus SeedStatus { get; set; }
    public decimal Price { get; set; }
}

