using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horga_Alexandra_Proiect.Migrations
{
    public partial class Doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocID",
                table: "Pacient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doc", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_DocID",
                table: "Pacient",
                column: "DocID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Doc_DocID",
                table: "Pacient",
                column: "DocID",
                principalTable: "Doc",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Doc_DocID",
                table: "Pacient");

            migrationBuilder.DropTable(
                name: "Doc");

            migrationBuilder.DropIndex(
                name: "IX_Pacient_DocID",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "DocID",
                table: "Pacient");
        }
    }
}
