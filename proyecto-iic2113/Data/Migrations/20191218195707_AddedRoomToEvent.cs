using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddedRoomToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_RoomId",
                table: "Events",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Rooms_RoomId",
                table: "Events",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Rooms_RoomId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RoomId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Events");
        }
    }
}
