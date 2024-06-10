using HotelReservationApp.Areas.Identity.Data;
using HotelReservationApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HotelReservationApp.Areas.Identity.Data;

public class HotelReservationDbContext : IdentityDbContext<HotelReservationAppUser>
{
    public HotelReservationDbContext(DbContextOptions<HotelReservationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Room>()
              .HasOne(r => r.Hotel)
              .WithMany(h => h.Rooms)
              .HasForeignKey(r => r.HotelId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Room>().HasData(
         new Room { RoomId = 1, HotelId = 1, RoomType = "Single", Price = 3000, IsAvailable = true, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 3) },
         new Room { RoomId = 2, HotelId = 1, RoomType = "Double", Price = 6000, IsAvailable = true, StartDate = new DateTime(2024, 6, 4), EndDate = new DateTime(2024, 6, 6) },
         new Room { RoomId = 3, HotelId = 2, RoomType = "Single", Price = 2000, IsAvailable = true, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 3) },
         new Room { RoomId = 4, HotelId = 2, RoomType = "Double", Price = 4000, IsAvailable = true, StartDate = new DateTime(2024, 6, 4), EndDate = new DateTime(2024, 6, 6) },
         new Room { RoomId = 5, HotelId = 3, RoomType = "Double", Price = 4000, IsAvailable = true, StartDate = new DateTime(2024, 6, 4), EndDate = new DateTime(2024, 6, 6) }
         );
        builder.Entity<Hotel>().HasData(
         new Hotel { HotelId = 1, Capacity = 3000, Description= "Ege Denizi'nin nefes kesen manzarasıyla eşsiz güzellikler sunan İzmir Marriott, konfor ve zarafeti odağına alarak tasarlanmış 7 süit ve 142 odası ile misafirlerini bekliyor. Rahatınız için tüm detayları düşünülmüş toplantı odalarında ister bir etkinliğe katılabilir, ister misafirlerinizle toplantı yapabilirsiniz.", HotelName="İzmir Marriott Hotel",PictureUrl= "/Images/marriott.jpg",Location="Alsancak,İzmir" },
         new Hotel { HotelId = 2, Capacity = 3000, Description = "İzmir, Türkiye'nin batı sahilinin incisi olarak bilinir. Yaz aylarında Ege plajlarını ziyaret eden turistler için çok popüler bir destinasyon ve sonbahar, kış ve ilkbaharda ticari ve kültürel bir temas bölgesidir. Bu ziyaretçilerin konaklama ihtiyaçlarını karşılamak için Swissotel Büyük Efes İzmir tüm konfor ve lüks beklentilerini karşılamaktadır. Swissotel Büyük Efes İzmir, toplantılar, konferanslar, düğün ve resepsiyon organizasyonları gibi küçük ve büyük ölçekli etkinlikler için popüler bir mekandır.", HotelName = "Swissotel Büyükefes İzmir", PictureUrl = "/Images/swiss.jpg", Location = "Alsancak,İzmir" },
         new Hotel { HotelId = 3, Capacity = 3000, Description = "Toplam 50.000 m2 arazi üzerine kurulan Kefaluka Resort Hotel denize sıfır konumdadır. Bodrum Akyarlar’da kurulmuş olan KEFALUKA Resort, Milas Havaalanına 60 km,Turgutreis şehir merkezine 10 km, ve Bodrum şehir merkezine 25 km uzaklıktadır.", HotelName = "Kefaluka Resort", PictureUrl = "/Images/KefalukaResort.jpg", Location = "Bodrum,Muğla" }
         );


    }


}


