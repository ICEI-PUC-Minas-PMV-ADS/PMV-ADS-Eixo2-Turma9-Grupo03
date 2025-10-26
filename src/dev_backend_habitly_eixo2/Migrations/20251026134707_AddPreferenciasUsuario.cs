using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class AddPreferenciasUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreferenciasUsuario",
                columns: table => new
                {
                    IdPreferencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NotificacoesAtivas = table.Column<bool>(type: "bit", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenciasUsuario", x => x.IdPreferencia);
                    table.ForeignKey(
                        name: "FK_PreferenciasUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreferenciasUsuario_IdUsuario",
                table: "PreferenciasUsuario",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferenciasUsuario");
        }
    }
}
