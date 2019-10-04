using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddSponsorsToConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Sponsors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_ConferenceId",
                table: "Sponsors",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_ConferenceId",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Sponsors");
        }
    }
}
