using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddEventUserAttendeeDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUserAttendee_AspNetUsers_ApplicationUserId",
                table: "EventUserAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUserAttendee_Events_EventId",
                table: "EventUserAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUserAttendee",
                table: "EventUserAttendee");

            migrationBuilder.RenameTable(
                name: "EventUserAttendee",
                newName: "EventUserAttendees");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserAttendee_EventId",
                table: "EventUserAttendees",
                newName: "IX_EventUserAttendees_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserAttendee_ApplicationUserId",
                table: "EventUserAttendees",
                newName: "IX_EventUserAttendees_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUserAttendees",
                table: "EventUserAttendees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserAttendees_AspNetUsers_ApplicationUserId",
                table: "EventUserAttendees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserAttendees_Events_EventId",
                table: "EventUserAttendees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUserAttendees_AspNetUsers_ApplicationUserId",
                table: "EventUserAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUserAttendees_Events_EventId",
                table: "EventUserAttendees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUserAttendees",
                table: "EventUserAttendees");

            migrationBuilder.RenameTable(
                name: "EventUserAttendees",
                newName: "EventUserAttendee");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserAttendees_EventId",
                table: "EventUserAttendee",
                newName: "IX_EventUserAttendee_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUserAttendees_ApplicationUserId",
                table: "EventUserAttendee",
                newName: "IX_EventUserAttendee_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUserAttendee",
                table: "EventUserAttendee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserAttendee_AspNetUsers_ApplicationUserId",
                table: "EventUserAttendee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserAttendee_Events_EventId",
                table: "EventUserAttendee",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
