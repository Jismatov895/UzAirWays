using Microsoft.EntityFrameworkCore;
using UzAirWays.Domain.Entities;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost; Database=UzAirway; Port=5432; User ID=postgres; Password=");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>()
            .HasOne(flight => flight.FirstAirport)
            .WithMany()
            .HasForeignKey(flight => flight.FirstAirportId);

        modelBuilder.Entity<Flight>()
            .HasOne(flight => flight.LastAirport)
            .WithMany()
            .HasForeignKey(flight => flight.LastAirportId);

        modelBuilder.Entity<Flight>()
           .HasOne(flight => flight.Plane)
           .WithMany()
           .HasForeignKey(flight => flight.PlaneId);

        modelBuilder.Entity<Ticket>()
           .HasOne(ticket => ticket.User)
           .WithMany()
           .HasForeignKey(ticket => ticket.UserId);

        modelBuilder.Entity<Ticket>()
           .HasOne(ticket => ticket.Flight)
           .WithMany(flight => flight.Tickets)
           .HasForeignKey(ticket => ticket.FlightId);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}