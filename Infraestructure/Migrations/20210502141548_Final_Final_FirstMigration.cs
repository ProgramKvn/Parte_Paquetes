using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class Final_Final_FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    DUI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Cliente"),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "https://localhost:44356/uploads/Usuarios/user-icon-default.png")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZONESV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ZoneName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZONESV", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Id_Paquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    String_Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido_Paquete = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tipo_Contenido = table.Column<int>(type: "int", nullable: false),
                    Estado_Paquete = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Pendiente"),
                    Envio_Prioridad = table.Column<bool>(type: "bit", nullable: false),
                    Peso_Contenido = table.Column<double>(type: "float", nullable: false),
                    Monto_Pagar_Prop = table.Column<double>(type: "float", nullable: false),
                    Estado_Pago = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Fecha_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Id_Paquete);
                    table.ForeignKey(
                        name: "FK_Paquetes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registro_Pagos",
                columns: table => new
                {
                    Id_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaqueteId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Monto_Pagado = table.Column<double>(type: "float", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 5, 2, 8, 15, 47, 736, DateTimeKind.Local).AddTicks(2382))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Pagos", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Registro_Pagos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPSV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DepName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISOCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ZONESV_ID = table.Column<int>(type: "int", nullable: false),
                    ZoneSVID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPSV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEPSV_ZONESV_ZoneSVID",
                        column: x => x.ZoneSVID,
                        principalTable: "ZONESV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MUNSV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MunName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DEPSV_ID = table.Column<int>(type: "int", nullable: false),
                    DepSVID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUNSV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MUNSV_DEPSV_DepSVID",
                        column: x => x.DepSVID,
                        principalTable: "DEPSV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEPSV_ZoneSVID",
                table: "DEPSV",
                column: "ZoneSVID");

            migrationBuilder.CreateIndex(
                name: "IX_MUNSV_DepSVID",
                table: "MUNSV",
                column: "DepSVID");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_UserId",
                table: "Paquetes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Pagos_UserID",
                table: "Registro_Pagos",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DUI",
                table: "Users",
                column: "DUI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MUNSV");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Registro_Pagos");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "DEPSV");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ZONESV");

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id_Paquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id_Paquete);
                });
        }
    }
}
