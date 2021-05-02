using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registro_Pagos",
                newName: "Id_Pago");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 19, 51, 17, 746, DateTimeKind.Local).AddTicks(3847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 19, 46, 7, 949, DateTimeKind.Local).AddTicks(3070));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Pago",
                table: "Registro_Pagos",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 19, 46, 7, 949, DateTimeKind.Local).AddTicks(3070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 19, 51, 17, 746, DateTimeKind.Local).AddTicks(3847));
        }
    }
}
