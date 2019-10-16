using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddOrganizerToConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizerId",
                table: "Conferences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_OrganizerId",
                table: "Conferences",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_AspNetUsers_OrganizerId",
                table: "Conferences",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_AspNetUsers_OrganizerId",
                table: "Conferences");

            migrationBuilder.DropIndex(
                name: "IX_Conferences_OrganizerId",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Conferences");
        }
    }
}
