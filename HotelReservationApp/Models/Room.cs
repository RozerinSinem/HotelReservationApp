namespace HotelReservationApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int? RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
