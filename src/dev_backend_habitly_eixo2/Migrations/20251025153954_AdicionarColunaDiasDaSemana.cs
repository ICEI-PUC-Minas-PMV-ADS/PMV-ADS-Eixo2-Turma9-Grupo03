using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class AdicionarColunaDiasDaSemana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodicidadeHabito",
                table: "Habitos");

            migrationBuilder.AddColumn<string>(
                name: "DiasDaSemana",
                table: "Habitos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasDaSemana",
                table: "Habitos");

            migrationBuilder.AddColumn<int>(
                name: "PeriodicidadeHabito",
                table: "Habitos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
