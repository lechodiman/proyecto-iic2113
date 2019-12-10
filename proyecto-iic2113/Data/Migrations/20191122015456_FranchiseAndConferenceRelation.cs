using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class FranchiseAndConferenceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Conferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_FranchiseId",
                table: "Conferences",
                column: "FranchiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_Franchise_FranchiseId",
                table: "Conferences",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_Franchise_FranchiseId",
                table: "Conferences");

            migrationBuilder.DropIndex(
                name: "IX_Conferences_FranchiseId",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Conferences");
        }
    }
}
