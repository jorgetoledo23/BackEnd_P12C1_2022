using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEntityFramework.Migrations
{
    public partial class Ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblVentas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<int>(type: "int", nullable: false),
                    ClienteRut = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVentas_tblClientes_ClienteRut",
                        column: x => x.ClienteRut,
                        principalTable: "tblClientes",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVentas_ClienteRut",
                table: "tblVentas",
                column: "ClienteRut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblVentas");
        }
    }
}
