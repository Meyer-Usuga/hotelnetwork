using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelNetwork.Migrations
{
    public partial class TableRoomsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MaxGuests = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    hotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelsId",
                table: "Rooms",
                column: "HotelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Number_hotelId",
                table: "Rooms",
                columns: new[] { "Number", "hotelId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
