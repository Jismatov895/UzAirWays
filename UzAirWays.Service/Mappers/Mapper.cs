using System.Net.Sockets;
using ToshiChilonzor.Domain.Entities;
using UzAirWays.Domain.Entities;
using UzAirWays.Service.DTOs.Airports;
using UzAirWays.Service.DTOs.Planes;
using UzAirWays.Service.DTOs.Tickets;
using UzAirWays.Service.DTOs.Users;

namespace UzAirWays.Service.Mappers;

public static class Mapper
{
    public static User Map(UserCreateModel createModel)
    {
        return new User
        {
            FirstName = createModel.FirstName,
            LastName = createModel.LastName,
            Password = createModel.Password,
            Email = createModel.Email,
        };
    }
       public static UserViewModel Map(User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
 
        };
    }

    public static IEnumerable<UserViewModel> Map(List<User> user)
    {
        var result = new List<UserViewModel>();
        user.ForEach(user => result.Add(new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,

        }));

        return result;
    }


    public static Plane Map(PlaneCreateModel createModel)
    {
        return new Plane
        {
            Number = createModel.Number,
            EconomSeats = createModel.EconomSeats,
            BusinessSeats = createModel.BusinessSeats,
        };
    }

    public static PlaneViewModel Map(Plane plane)
    {
        return new PlaneViewModel
        {
            Number = plane.Number,
            EconomSeats = plane.EconomSeats,
            BusinessSeats = plane.BusinessSeats,
        };
    }
    public static IEnumerable<PlaneViewModel> Map(List<Plane> plane)
    {
        var result = new List<PlaneViewModel>();
        plane.ForEach(plane => result.Add(new PlaneViewModel
        {
            Id = plane.Id,
            Number = plane.Number,
            EconomSeats = plane.EconomSeats,
            BusinessSeats = plane.BusinessSeats,


        }));

        return result;
    }

    public static Airport Map(AirportCreateModel createModel)
    {
        return new Airport
        {
            Name = createModel.Name,
            Country = createModel.Country,
            City = createModel.City,
            Address = createModel.Address,
        };
    }

    public static AirportViewModel Map(Airport airport)
    {
        return new AirportViewModel
        {
            Name = airport.Name,
            Country = airport.Country,
            City = airport.City,
            Address = airport.Address,

        };
    }

    public static IEnumerable<AirportViewModel> Map(IEnumerable<Airport> airports)
    {
        return airports.Select(airport => new AirportViewModel
        {
            Id = airport.Id,
            Name = airport.Name,
            Country = airport.Country,
            City = airport.City,
            Address = airport.Address,

        });
    }
    public static Flight Map(FlightCreateModel createModel)
    {
        return new Flight
        {
            PlaneId = createModel.PlaneId,
            FirstAirportId = createModel.FirstAirportId,
            LastAirportId = createModel.LastAirportId,
            StartDate = createModel.StartDate,
            EconomPrice = createModel.EconomPrice,
            EndDate = createModel.EndDate,
            BusinessPrice = createModel.BusinessPrice,

        };
    }

    public static FlightViewModel Map(Flight flight)
    {
        return new FlightViewModel
        {
            FirstAirport = Map(flight.FirstAirport),
            LastAirport = Map(flight.LastAirport),
            Plane = Map(flight.Plane),
            Tickets = Map(flight.Tickets),
            BusinessPrice = flight.BusinessPrice,
            EconomPrice = flight.EconomPrice,
            StartDate = flight.StartDate,
            EndDate = flight.EndDate,


        };
    }

    public static IEnumerable<FlightViewModel> Map(IEnumerable<Flight> flights)
    {
        return flights.Select(flight => new FlightViewModel
        {
            Id = flight.Id,
            FirstAirport = Map(flight.FirstAirport),
            LastAirport = Map(flight.LastAirport),
            Plane = Map(flight.Plane),
            Tickets = Map(flight.Tickets),
            BusinessPrice = flight.BusinessPrice,
            EconomPrice = flight.EconomPrice,
            StartDate = flight.StartDate,
            EndDate = flight.EndDate,

        });


    }

    public static Ticket Map(TicketCreateModel createModel)
    {
        return new Ticket
        {
            Price = createModel.Price,
            UserId = createModel.UserId,
            FlightId = createModel.FlightId,
            SeedStatus = createModel.SeedStatus,
        };
    }

    public static TicketViewModel Map(Ticket ticket)
    {
        return new TicketViewModel
        {
            Price = ticket.Price,
            SeedStatus = ticket.SeedStatus,
            User = Map(ticket.User),
            Flight = Map(ticket.Flight),
        };
    }
    public static IEnumerable<TicketViewModel> Map(IEnumerable<Ticket> ticket)
    {
        return ticket.Select(ticket => new TicketViewModel
        {
            Id = ticket.Id,
            Price = ticket.Price,
            SeedStatus = ticket.SeedStatus,
            User = Map(ticket.User),
            Flight = Map(ticket.Flight),
        });

    }

}


