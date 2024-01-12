using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horga_Alexandra_Proiect.Migrations
{
    public partial class asistent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsistentID",
                table: "Pacient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Asistent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistent", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_AsistentID",
                table: "Pacient",
                column: "AsistentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacient_Asistent_AsistentID",
                table: "Pacient",
                column: "AsistentID",
                principalTable: "Asistent",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacient_Asistent_AsistentID",
                table: "Pacient");

            migrationBuilder.DropTable(
                name: "Asistent");

            migrationBuilder.DropIndex(
                name: "IX_Pacient_AsistentID",
                table: "Pacient");

            migrationBuilder.DropColumn(
                name: "AsistentID",
                table: "Pacient");
        }
    }
}
