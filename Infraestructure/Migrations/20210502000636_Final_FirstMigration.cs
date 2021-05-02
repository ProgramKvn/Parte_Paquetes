using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    String_Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido_Paquete = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tipo_Contenido = table.Column<int>(type: "int", nullable: false),
                    Estado_Paquete = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Pendiente"),
                    Envio_Prioridad = table.Column<bool>(type: "bit", nullable: false),
                    Peso_Contenido = table.Column<double>(type: "float", nullable: false),
                    Monto_Pagar_Prop = table.Column<double>(type: "float", nullable: false),
                    Estado_Pago = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Fecha_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registro_Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    Monto_Pagado = table.Column<double>(type: "float", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 1, 18, 6, 36, 337, DateTimeKind.Local).AddTicks(206))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_Pagos_Paquetes_PaqueteId",
                        column: x => x.PaqueteId,
                        principalTable: "Paquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Pagos_PaqueteId",
                table: "Registro_Pagos",
                column: "PaqueteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro_Pagos");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });
        }
    }
}
