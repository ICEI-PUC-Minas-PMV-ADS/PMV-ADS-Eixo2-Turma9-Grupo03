using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class AddEtiquetasAndHabitoArquivado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsArquivado",
                table: "Habitos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    IdEtiqueta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.IdEtiqueta);
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaHabito",
                columns: table => new
                {
                    EtiquetasIdEtiqueta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HabitosIdHabito = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaHabito", x => new { x.EtiquetasIdEtiqueta, x.HabitosIdHabito });
                    table.ForeignKey(
                        name: "FK_EtiquetaHabito_Etiquetas_EtiquetasIdEtiqueta",
                        column: x => x.EtiquetasIdEtiqueta,
                        principalTable: "Etiquetas",
                        principalColumn: "IdEtiqueta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaHabito_Habitos_HabitosIdHabito",
                        column: x => x.HabitosIdHabito,
                        principalTable: "Habitos",
                        principalColumn: "IdHabito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaHabito_HabitosIdHabito",
                table: "EtiquetaHabito",
                column: "HabitosIdHabito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiquetaHabito");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IsArquivado",
                table: "Habitos");
        }
    }
}
