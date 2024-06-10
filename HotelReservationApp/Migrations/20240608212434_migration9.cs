using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Capacity", "Description", "HotelName", "Location", "PictureUrl" },
                values: new object[,]
                {
                    { 1, 3000, "Ege Denizi'nin nefes kesen manzarasıyla eşsiz güzellikler sunan İzmir Marriott, konfor ve zarafeti odağına alarak tasarlanmış 7 süit ve 142 odası ile misafirlerini bekliyor. Rahatınız için tüm detayları düşünülmüş toplantı odalarında ister bir etkinliğe katılabilir, ister misafirlerinizle toplantı yapabilirsiniz.", "İzmir Marriott Hotel", "Alsancak,İzmir", "/Images/marriott.jpg" },
                    { 2, 3000, "İzmir, Türkiye'nin batı sahilinin incisi olarak bilinir. Yaz aylarında Ege plajlarını ziyaret eden turistler için çok popüler bir destinasyon ve sonbahar, kış ve ilkbaharda ticari ve kültürel bir temas bölgesidir. Bu ziyaretçilerin konaklama ihtiyaçlarını karşılamak için Swissotel Büyük Efes İzmir tüm konfor ve lüks beklentilerini karşılamaktadır. Swissotel Büyük Efes İzmir, toplantılar, konferanslar, düğün ve resepsiyon organizasyonları gibi küçük ve büyük ölçekli etkinlikler için popüler bir mekandır.", "Swissotel Büyükefes İzmir", "Alsancak,İzmir", "/Images/swiss.jpg" },
                    { 3, 3000, "Toplam 50.000 m2 arazi üzerine kurulan Kefaluka Resort Hotel denize sıfır konumdadır. Bodrum Akyarlar’da kurulmuş olan KEFALUKA Resort, Milas Havaalanına 60 km,Turgutreis şehir merkezine 10 km, ve Bodrum şehir merkezine 25 km uzaklıktadır.", "Kefaluka Resort", "Bodrum,Muğla", "/Images/KefalukaResort.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "EndDate", "HotelId", "IsAvailable", "Price", "RoomType", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 3000m, "Single", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 6000m, "Double", new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2000m, "Single", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 4000m, "Double", new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 4000m, "Double", new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);
        }
    }
}
