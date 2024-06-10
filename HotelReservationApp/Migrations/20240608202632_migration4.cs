using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Capacity", "Description", "EndDate", "IsAvailable", "Location", "Name", "PictureUrl", "Price", "RoomNumber", "RoomType", "StartDate" },
                values: new object[,]
                {
                    { 1, 100, null, null, true, null, "İzmir Marriott Hotel", "/Images/marriott.jpg", 3000m, null, null, null },
                    { 2, 200, null, null, true, null, "Swissotel Büyükefes izmir", "/Images/Swiss.jpg", 2500m, null, null, null },
                    { 3, 200, null, null, true, null, "Kefaluka Resort Bodrum", "/Images/KefalukaResort.jpg", 4000m, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
