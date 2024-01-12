using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horga_Alexandra_Proiect.Migrations
{
    public partial class CategoriePacient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoriePacient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriePacient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoriePacient_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriePacient_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriePacient_CategorieID",
                table: "CategoriePacient",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriePacient_PacientID",
                table: "CategoriePacient",
                column: "PacientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriePacient");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
