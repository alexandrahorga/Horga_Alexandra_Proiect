using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horga_Alexandra_Proiect.Migrations
{
    public partial class Vizite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VizitaID",
                table: "Pacient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembruFamilie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembruFamilie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vizite",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruFamilieID = table.Column<int>(type: "int", nullable: true),
                    PacientID = table.Column<int>(type: "int", nullable: true),
                    DataVizita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizite", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vizite_MembruFamilie_MembruFamilieID",
                        column: x => x.MembruFamilieID,
                        principalTable: "MembruFamilie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vizite_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vizite_MembruFamilieID",
                table: "Vizite",
                column: "MembruFamilieID");

            migrationBuilder.CreateIndex(
                name: "IX_Vizite_PacientID",
                table: "Vizite",
                column: "PacientID",
                unique: true,
                filter: "[PacientID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vizite");

            migrationBuilder.DropTable(
                name: "MembruFamilie");

            migrationBuilder.DropColumn(
                name: "VizitaID",
                table: "Pacient");
        }
    }
}
