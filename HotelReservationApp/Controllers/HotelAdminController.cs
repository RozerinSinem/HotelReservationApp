using HotelReservationApp.Models;
using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers
{
    public class HotelAdminController : Controller
    {
        private readonly HotelAdminService _hotelService;

        public HotelAdminController(HotelAdminService hotelAdminService)
        {
            _hotelService = hotelAdminService;
        }

        public IActionResult Listing()
        {
            List<Hotel> hotels = _hotelService.GetAllHotels();
            return View(hotels);
        }

        [HttpGet]
        public IActionResult AddRoomForm(int hotelId)
        {
            var hotel = _hotelService.GetHotelById(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            ViewBag.HotelName = hotel.HotelName;
            return PartialView("_AddRoom", new Room { HotelId = hotelId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveRoom(Room room)
        {
            
                await _hotelService.AddRoom(room);
                return RedirectToAction("Listing");
            

        }

        public IActionResult UpdateRooms(int hotelId)
        {
            Hotel hotel = _hotelService.GetHotelByIdWithRooms(hotelId); 
            return View("_UpdateRoomsList", hotel);
        }

        public IActionResult GetRoom(int roomId)
        {
            var room = _hotelService.GetRoomById(roomId);
            return PartialView("_UpdateRoomPopup", room);
        }

        [HttpPost]
        public IActionResult UpdateRoom(Room room)
        {
            var roomToUpdate = _hotelService.GetRoomById(room.RoomId);

            if (roomToUpdate != null)
            {
                // Update room properties with new values
                roomToUpdate.StartDate = room.StartDate;
                roomToUpdate.EndDate = room.EndDate;
                roomToUpdate.RoomType = room.RoomType;
                roomToUpdate.RoomNumber = room.RoomNumber;
                roomToUpdate.Price = room.Price;
                roomToUpdate.IsAvailable = room.IsAvailable;

                // Save changes to the database
                _hotelService.UpdateRoom(roomToUpdate);

                return Json(new { success = true, message = "Room updated successfully." });
            }

            return Json(new { success = false, message = "Room not found." });
        }

    }
}
