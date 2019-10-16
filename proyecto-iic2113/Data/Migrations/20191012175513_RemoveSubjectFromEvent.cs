using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class RemoveSubjectFromEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Events",
                nullable: true);
        }
    }
}
