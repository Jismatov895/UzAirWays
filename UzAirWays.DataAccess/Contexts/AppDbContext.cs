using Microsoft.EntityFrameworkCore;
using UzAirWays.Domain.Entities;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost; Database=UzAirway; Port=5432; User ID=postgres; Password=");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}