using Microsoft.EntityFrameworkCore.Migrations;

namespace proyecto_iic2113.Migrations
{
    public partial class Addres_required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Venues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Venues",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
