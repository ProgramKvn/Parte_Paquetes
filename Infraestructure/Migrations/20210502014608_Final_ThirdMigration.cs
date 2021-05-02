﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 19, 46, 7, 949, DateTimeKind.Local).AddTicks(3070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 19, 37, 42, 524, DateTimeKind.Local).AddTicks(3074));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Pago",
                table: "Registro_Pagos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 1, 19, 37, 42, 524, DateTimeKind.Local).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 1, 19, 46, 7, 949, DateTimeKind.Local).AddTicks(3070));
        }
    }
}