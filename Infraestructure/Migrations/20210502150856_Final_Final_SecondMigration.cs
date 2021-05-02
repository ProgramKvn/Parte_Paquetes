using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_Final_SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 9, 8, 54, 427, DateTimeKind.Local).AddTicks(3837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 8, 15, 47, 736, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.AlterColumn<string>(
                name: "Origen",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Paquetes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 2, 8, 15, 47, 736, DateTimeKind.Local).AddTicks(2382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 2, 9, 8, 54, 427, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.AlterColumn<string>(
                name: "Origen",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Departamento",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
