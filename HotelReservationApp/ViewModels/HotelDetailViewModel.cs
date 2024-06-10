using HotelReservationApp.Models;
using System;
using System.Collections.Generic;

namespace HotelReservationApp.ViewModels
{
    public class HotelDetailViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Guests { get; set; }
    }
}
