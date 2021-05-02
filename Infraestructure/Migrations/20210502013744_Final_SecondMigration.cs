using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 19, 37, 42, 524, DateTimeKind.Local).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 18, 6, 36, 337, DateTimeKind.Local).AddTicks(206));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 18, 6, 36, 337, DateTimeKind.Local).AddTicks(206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 19, 37, 42, 524, DateTimeKind.Local).AddTicks(3074));
        }
    }
}
