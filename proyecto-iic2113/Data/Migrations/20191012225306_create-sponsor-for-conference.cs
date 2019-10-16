using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class createsponsorforconference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Sponsors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Sponsors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Conferences_ConferenceId",
                table: "Sponsors",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
