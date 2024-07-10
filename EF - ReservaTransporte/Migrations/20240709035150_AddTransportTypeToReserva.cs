using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF___ReservaTransporte.Migrations
{
    /// <inheritdoc />
    public partial class AddTransportTypeToReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    ConductorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conducto__BDDAB680CA7952E7", x => x.ConductorId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__AA088600E7726097", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    ConductorId = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    UbicacionOrigen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UbicacionDestino = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Confirmada = table.Column<bool>(type: "bit", nullable: false),
                    TransportType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserva__C3993763015BAFB3", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK__Reserva__Conduct__4E88ABD4",
                        column: x => x.ConductorId,
                        principalTable: "Conductor",
                        principalColumn: "ConductorId");
                    table.ForeignKey(
                        name: "FK__Reserva__Vehicul__4D94879B",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "VehiculoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ConductorId",
                table: "Reserva",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VehiculoId",
                table: "Reserva",
                column: "VehiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
