using HotelReservationApp.Services;
using HotelReservationApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using HotelReservationApp.Areas.Identity.Data;

namespace HotelReservationApp.Controllers
{
    public class SearchHotelController : Controller
    {
        private readonly SearchHotelService _searchService;
        private readonly UserManager<HotelReservationAppUser> _userManager;
        private readonly IEmailService _emailService;
        public SearchHotelController(SearchHotelService searchHotelService ,UserManager<HotelReservationAppUser> userManager, IEmailService emailService)
        {
            _searchService = searchHotelService;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchHotelViewModel());
        }

        [HttpPost]
        public IActionResult Search(SearchHotelViewModel model)
        {
            var hotels = _searchService.SearchHotels(model.Location, model.StartDate, model.EndDate, model.Guests);
            model.Hotels = hotels;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id, DateTime startDate, DateTime endDate, int guests)
        {
            var hotel = _searchService.GetHotelById(id);
            var rooms = _searchService.GetAvailableRooms(id, startDate, endDate);

           


            var model = new HotelDetailViewModel
            {
                HotelId = hotel.HotelId,
                HotelName = hotel.HotelName,
                Location = hotel.Location,
                Description = hotel.Description,
                PictureUrl = hotel.PictureUrl,
                Rooms = rooms,
                StartDate = startDate,
                EndDate = endDate,
                Guests = guests
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReserveRoom(int roomId, int hotelId, DateTime startDate, DateTime endDate, int guests)
        {
            var success = _searchService.ReserveRoom(roomId, guests);

            if (success)
            {
                var room = _searchService.GetRoomById(roomId);
                var hotel = _searchService.GetHotelById(hotelId);

                var reservationDetails = $@"
                    <p><strong>Hotel Name:</strong> {hotel.HotelName}</p>
                    <p><strong>Room Type:</strong> {room.RoomType}</p>
                    <p><strong>Start Date:</strong> {startDate.ToString("yyyy-MM-dd")}</p>
                    <p><strong>End Date:</strong> {endDate.ToString("yyyy-MM-dd")}</p>
                    <p><strong>Guests:</strong> {guests}</p>
                ";

                // Send reservation details to the admin email
                var adminEmail = "rozerinsinemm@gmail.com"; // Admin email address
                await _emailService.SendEmailAsync(adminEmail, "New Reservation Details", reservationDetails);
            }

            return Json(new { success = success });
        }


    }
}
