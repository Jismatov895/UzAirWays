using UzAirWays.Domain.Commons;

namespace UzAirWays.Domain.Entities;
public class Airport : Auditable
{
    public string Name {  get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}
