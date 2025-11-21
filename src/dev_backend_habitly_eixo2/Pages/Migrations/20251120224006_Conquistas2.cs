using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class Conquistas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArquivado",
                table: "Habitos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TagsCsv",
                table: "Habitos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArquivado",
                table: "Habitos");

            migrationBuilder.DropColumn(
                name: "TagsCsv",
                table: "Habitos");
        }
    }
}
