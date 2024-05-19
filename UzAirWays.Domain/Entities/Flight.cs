
using System.Numerics;
using UzAirWays.Domain.Commons;

namespace UzAirWays.Domain.Entities;
public class Flight : Auditable
{
    public long PlaneId { get; set; }
    public Plane Plane { get; set; }
    public long FirstAirportId { get; set; }
    public Airport FirstAirport { get; set; }
    public long LastAirportId { get; set; }
    public Airport LastAirport { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EconomPrice { get; set; }
    public decimal BusinessPrice { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}

