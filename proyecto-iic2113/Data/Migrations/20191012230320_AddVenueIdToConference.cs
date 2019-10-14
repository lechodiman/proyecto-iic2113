using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace proyecto_iic2113.Migrations
{
    public partial class AddVenueIdToConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Conferences",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    VenueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venues_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_VenueId",
                table: "Conferences",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueId",
                table: "Venues",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Conferences_VenueId",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Conferences");
        }
    }
}
