using UzAirWays.Domain.Commons;
using UzAirWays.Domain.Enums;

namespace UzAirWays.Domain.Entities;
public class Ticket : Auditable
{
    public long FlightId { get; set; }
    public Flight Flight { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public SeedStatus SeedStatus { get; set; }
    public decimal Price { get; set; }
}
