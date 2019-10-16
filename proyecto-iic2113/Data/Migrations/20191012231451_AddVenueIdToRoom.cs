using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddVenueIdToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Venues_VenueId",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_VenueId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Venues");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_VenueId",
                table: "Rooms",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Venues_VenueId",
                table: "Rooms",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Venues_VenueId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_VenueId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Venues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueId",
                table: "Venues",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Venues_VenueId",
                table: "Venues",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
