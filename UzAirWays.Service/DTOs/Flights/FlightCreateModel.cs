namespace ToshiChilonzor.Domain.Entities;

public class FlightCreateModel
{
    public long PlaneId { get; set; }
    public long FirstAirportId { get; set; }
    public long LastAirportId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal EconomPrice { get; set; }
    public decimal BusinessPrice { get; set; }
}
