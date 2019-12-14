using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class FranchiseHasOrganizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizerId",
                table: "Franchise",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Franchise_OrganizerId",
                table: "Franchise",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Franchise_AspNetUsers_OrganizerId",
                table: "Franchise",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Franchise_AspNetUsers_OrganizerId",
                table: "Franchise");

            migrationBuilder.DropIndex(
                name: "IX_Franchise_OrganizerId",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Franchise");
        }
    }
}
