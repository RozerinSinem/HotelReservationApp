using System.Collections.Generic;
using HotelReservationApp.Models;

namespace HotelReservationApp.ViewModels
{
    public class SearchHotelViewModel
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Guests { get; set; }
        public List<Hotel> Hotels { get; set; } // Add this property
    }
}
