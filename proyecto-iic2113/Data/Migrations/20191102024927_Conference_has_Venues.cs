using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class Conference_has_Venues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Conferences",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conferences",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Conferences",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Conferences",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Venues_VenueId",
                table: "Conferences",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
