using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationApp.Services
{
    public class SearchHotelService
    {
        private readonly HotelReservationDbContext _context;

        public SearchHotelService(HotelReservationDbContext context)
        {
            _context = context;
        }

        public List<Hotel> SearchHotels(string location, DateTime startDate, DateTime endDate, int guests)
        {
            var availableRooms = _context.Rooms
                .Where(room => room.IsAvailable && room.StartDate <= startDate && room.EndDate >= endDate)
                .ToList();

            var availableHotels = _context.Hotels
                .Where(hotel => hotel.Location == location && hotel.Capacity >= guests)
                .ToList();

            var hotelsWithAvailableRooms = availableHotels
                .Where(hotel => availableRooms.Any(room => room.HotelId == hotel.HotelId))
                .ToList();

            return hotelsWithAvailableRooms;
        }

        public Hotel GetHotelById(int id)
        {
            return _context.Hotels.FirstOrDefault(h => h.HotelId == id);
        }
        public Room GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefault(h => h.RoomId == id);
        }

        public List<Room> GetAvailableRooms(int hotelId, DateTime startDate, DateTime endDate)
        {
            return _context.Rooms
                .Where(room => room.HotelId == hotelId && room.IsAvailable && room.StartDate <= startDate && room.EndDate >= endDate)
                .ToList();
        }

        public bool ReserveRoom(int roomId, int guests)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room == null || !room.IsAvailable)
            {
                return false;
            }

            room.IsAvailable = false;
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == room.HotelId);
            if (hotel != null)
            {
                hotel.Capacity -= guests;
            }

            _context.SaveChanges();
            return true;
        }

    }
}
