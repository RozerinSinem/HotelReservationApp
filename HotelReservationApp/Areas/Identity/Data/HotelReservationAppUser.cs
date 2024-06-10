using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the HotelReservationAppUser class
public class HotelReservationAppUser : IdentityUser
{
    public string? Name { get; set; }
    public string ?Password { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsPremium { get; set; }
}

