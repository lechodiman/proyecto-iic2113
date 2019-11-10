using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddConferenceUserAttendeeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferenceUserAttendee",
                columns : table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                        ConferenceId = table.Column<int>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_ConferenceUserAttendee", x => new { x.ConferenceId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ConferenceUserAttendee_AspNetUsers_ApplicationUserId",
                        column : x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceUserAttendee_Conferences_ConferenceId",
                        column : x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceUserAttendee_ApplicationUserId",
                table: "ConferenceUserAttendee",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferenceUserAttendee");
        }
    }
}
