using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitos",
                columns: table => new
                {
                    IdHabito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    TituloHabito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoHabito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DiasDaSemana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusHabito = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
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
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
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
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Checkins",
                columns: table => new
                {
                    IdCheckin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHabito = table.Column<int>(type: "int", nullable: false),
                    DataCheckin = table.Column<DateTime>(type: "datetime", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    IdConquista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHabito = table.Column<int>(type: "int", nullable: false),
                    MetaDias = table.Column<int>(type: "int", nullable: false),
                    DataConquista = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.IdConquista);
                    table.ForeignKey(
                        name: "FK_Conquistas_Habitos_IdHabito",
                        column: x => x.IdHabito,
                        principalTable: "Habitos",
                        principalColumn: "IdHabito",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Checkins_IdHabito",
                table: "Checkins",
                column: "IdHabito");

            migrationBuilder.CreateIndex(
                name: "IX_Conquistas_IdHabito",
                table: "Conquistas",
                column: "IdHabito");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenciasUsuario_IdUsuario",
                table: "PreferenciasUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkins");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropTable(
                name: "Metricas");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "PreferenciasUsuario");

            migrationBuilder.DropTable(
                name: "Habitos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
