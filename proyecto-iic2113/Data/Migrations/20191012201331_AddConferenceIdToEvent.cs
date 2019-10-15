using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddConferenceIdToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ConferenceId",
                table: "Events",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Conferences_ConferenceId",
                table: "Events",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Conferences_ConferenceId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ConferenceId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Events");
        }
    }
}
