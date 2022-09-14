﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppEntityFramework.Migrations
{
    public partial class primeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductos");
        }
    }
}