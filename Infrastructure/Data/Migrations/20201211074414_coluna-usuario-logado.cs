using Microsoft.EntityFrameworkCore.Migrations;

namespace Multimidia.Api.Migrations
{
    public partial class colunausuariologado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLoggedIn",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLoggedIn",
                table: "Usuarios");
        }
    }
}
