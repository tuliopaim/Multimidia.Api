using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multimidia.Api
{
    public partial class CorrigeForeignUsuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Usuarios_UsuarioId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Videos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Usuarios_UsuarioId",
                table: "Videos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Usuarios_UsuarioId",
                table: "Videos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Videos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Usuarios_UsuarioId",
                table: "Videos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
