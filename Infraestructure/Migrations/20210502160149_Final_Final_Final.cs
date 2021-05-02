using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_Final_Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fotografia",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "https://localhost:44356/Uploads/Usuarios/user-icon-default.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "https://localhost:44356/uploads/Usuarios/user-icon-default.png");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 10, 1, 48, 75, DateTimeKind.Local).AddTicks(3099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 9, 8, 54, 427, DateTimeKind.Local).AddTicks(3837));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fotografia",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "https://localhost:44356/uploads/Usuarios/user-icon-default.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "https://localhost:44356/Uploads/Usuarios/user-icon-default.png");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 9, 8, 54, 427, DateTimeKind.Local).AddTicks(3837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 10, 1, 48, 75, DateTimeKind.Local).AddTicks(3099));
        }
    }
}
