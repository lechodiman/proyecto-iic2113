using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class AddRelationshipForLecturerAndExhibitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TalkLecturer",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    TalkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalkLecturer", x => new { x.TalkId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_TalkLecturer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalkLecturer_Events_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopExhibitor",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopExhibitor", x => new { x.WorkshopId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_WorkshopExhibitor_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopExhibitor_Events_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalkLecturer_ApplicationUserId",
                table: "TalkLecturer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopExhibitor_ApplicationUserId",
                table: "WorkshopExhibitor",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalkLecturer");

            migrationBuilder.DropTable(
                name: "WorkshopExhibitor");
        }
    }
}
