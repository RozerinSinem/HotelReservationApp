using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationApp.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Hotels",
                newName: "HotelName");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.RenameColumn(
                name: "HotelName",
                table: "Hotels",
                newName: "RoomType");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Hotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Hotels",
                type: "datetime2",
                nullable: true);

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
    }
}
