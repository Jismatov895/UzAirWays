﻿using UzAirWays.Domain.Commons;

namespace UzAirWays.Domain.Entities;
public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // public ICollection<Flight> Flights {get; set;}   i wanna add this collection but team dont want 
}
