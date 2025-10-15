using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class M01AddTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitos",
                columns: table => new
                {
                    IdHabito = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloHabito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoHabito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PeriodicidadeHabito = table.Column<int>(type: "int", nullable: false),
                    StatusHabito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitos", x => x.IdHabito);
                });

            migrationBuilder.CreateTable(
                name: "Metricas",
                columns: table => new
                {
                    IdMetrica = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreakAtual = table.Column<int>(type: "int", nullable: false),
                    StreakMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas", x => x.IdMetrica);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    IdNotificacao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.IdNotificacao);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Checkins",
                columns: table => new
                {
                    IdCheckin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHabito = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataCheckin = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkins", x => x.IdCheckin);
                    table.ForeignKey(
                        name: "FK_Checkins_Habitos_IdHabito",
                        column: x => x.IdHabito,
                        principalTable: "Habitos",
                        principalColumn: "IdHabito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkins_IdHabito",
                table: "Checkins",
                column: "IdHabito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkins");

            migrationBuilder.DropTable(
                name: "Metricas");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Habitos");
        }
    }
}
