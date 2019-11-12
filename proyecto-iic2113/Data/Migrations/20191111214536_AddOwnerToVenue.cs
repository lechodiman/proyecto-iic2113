using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddOwnerToVenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Venues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_OwnerId",
                table: "Venues",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_AspNetUsers_OwnerId",
                table: "Venues",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_AspNetUsers_OwnerId",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_OwnerId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Venues");
        }
    }
}
