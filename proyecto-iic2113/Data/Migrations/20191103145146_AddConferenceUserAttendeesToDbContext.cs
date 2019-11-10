using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddConferenceUserAttendeesToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUserAttendee_AspNetUsers_ApplicationUserId",
                table: "ConferenceUserAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUserAttendee_Conferences_ConferenceId",
                table: "ConferenceUserAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceUserAttendee",
                table: "ConferenceUserAttendee");

            migrationBuilder.RenameTable(
                name: "ConferenceUserAttendee",
                newName: "ConferenceUserAttendees");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceUserAttendee_ApplicationUserId",
                table: "ConferenceUserAttendees",
                newName: "IX_ConferenceUserAttendees_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceUserAttendees",
                table: "ConferenceUserAttendees",
                columns: new[] { "ConferenceId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUserAttendees_AspNetUsers_ApplicationUserId",
                table: "ConferenceUserAttendees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUserAttendees_Conferences_ConferenceId",
                table: "ConferenceUserAttendees",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUserAttendees_AspNetUsers_ApplicationUserId",
                table: "ConferenceUserAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUserAttendees_Conferences_ConferenceId",
                table: "ConferenceUserAttendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceUserAttendees",
                table: "ConferenceUserAttendees");

            migrationBuilder.RenameTable(
                name: "ConferenceUserAttendees",
                newName: "ConferenceUserAttendee");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceUserAttendees_ApplicationUserId",
                table: "ConferenceUserAttendee",
                newName: "IX_ConferenceUserAttendee_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceUserAttendee",
                table: "ConferenceUserAttendee",
                columns: new[] { "ConferenceId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUserAttendee_AspNetUsers_ApplicationUserId",
                table: "ConferenceUserAttendee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUserAttendee_Conferences_ConferenceId",
                table: "ConferenceUserAttendee",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
