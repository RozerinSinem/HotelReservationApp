namespace HotelReservationApp.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
      
        public int Capacity { get; set; }
        public string? HotelName { get; set; }
        public string? Location { get; set; }
        public string ?Description { get; set; }
        public string? PictureUrl { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
