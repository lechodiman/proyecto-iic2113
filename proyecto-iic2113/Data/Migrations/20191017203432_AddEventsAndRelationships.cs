using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace proyecto_iic2113.Migrations
{
    public partial class AddEventsAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Menus");

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Menus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LaunchId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasOpenBar",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatPanelist",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatPanelist", x => new { x.ChatId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ChatPanelist_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatPanelist_Events_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ResourceUrl = table.Column<string>(nullable: true),
                    WorkshopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Events_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_LaunchId",
                table: "Menus",
                column: "LaunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatPanelist_ApplicationUserId",
                table: "ChatPanelist",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_WorkshopId",
                table: "Resources",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Events_LaunchId",
                table: "Menus",
                column: "LaunchId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Events_LaunchId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "ChatPanelist");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Menus_LaunchId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "LaunchId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "HasOpenBar",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Menus",
                nullable: true);
        }
    }
}
