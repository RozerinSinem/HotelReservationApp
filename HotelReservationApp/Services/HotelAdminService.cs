using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApp.Services
{
    public class HotelAdminService
    {

        private readonly HotelReservationDbContext _context;

        public HotelAdminService (HotelReservationDbContext context)
        {
            _context = context;
        }

        public List<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _context.Hotels.FirstOrDefault(h => h.HotelId == id);
        }

        public async Task AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public Hotel GetHotelByIdWithRooms(int hotelId)
        {
            // Retrieve the hotel along with its associated rooms using Include
            return _context.Hotels
                 .Include(h => h.Rooms)
                 .FirstOrDefault(h => h.HotelId == hotelId);
        }

        public Room GetRoomById(int roomId)
        {
            // Retrieve the room with the specified ID
            return _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
