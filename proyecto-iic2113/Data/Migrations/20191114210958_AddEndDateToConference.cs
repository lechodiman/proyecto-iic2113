using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddEndDateToConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Conferences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Events_ConferenceId1",
                table: "Events",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ConferenceId2",
                table: "Events",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ConferenceId3",
                table: "Events",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ConferenceId4",
                table: "Events",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Conferences_ConferenceId1",
                table: "Events",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Conferences_ConferenceId2",
                table: "Events",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Conferences_ConferenceId3",
                table: "Events",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Conferences_ConferenceId4",
                table: "Events",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Conferences_ConferenceId1",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Conferences_ConferenceId2",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Conferences_ConferenceId3",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Conferences_ConferenceId4",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ConferenceId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ConferenceId2",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ConferenceId3",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ConferenceId4",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Conferences");
        }
    }
}
