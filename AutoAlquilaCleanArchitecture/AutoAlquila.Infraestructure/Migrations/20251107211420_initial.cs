using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoAlquila.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Direccion_Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Precio_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mantenimiento_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mantenimiento_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaUltimoAlquiler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Accesorios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "alquileres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Duracion_Inicio = table.Column<DateOnly>(type: "date", nullable: true),
                    Duracion_Fin = table.Column<DateOnly>(type: "date", nullable: true),
                    VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioPorPeriodo_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioPorPeriodo_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mantenimiento_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mantenimiento_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accesorios_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Accesorios_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioTotal_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioTotal_tipoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDenegacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCompletado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_alquileres_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alquileres_vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlquilerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comentarios_alquileres_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "alquileres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comentarios_vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_UsuarioId",
                table: "alquileres",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_VehiculoId",
                table: "alquileres",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_AlquilerId",
                table: "comentarios",
                column: "AlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_UsuarioId",
                table: "comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_VehiculoId",
                table: "comentarios",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                table: "usuarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "alquileres");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "vehiculos");
        }
    }
}
