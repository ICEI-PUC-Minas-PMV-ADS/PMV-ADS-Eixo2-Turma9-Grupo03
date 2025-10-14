using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habitly.Migrations
{
    public partial class M01AddTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Habito",
                columns: table => new
                {
                    IdHabito = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeHabito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoHabito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StatusHabito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habito", x => x.IdHabito);
                    table.ForeignKey(
                        name: "FK_Habito_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metrica",
                columns: table => new
                {
                    IdMetrica = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreakAtual = table.Column<int>(type: "int", nullable: false),
                    StreakMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrica", x => x.IdMetrica);
                    table.ForeignKey(
                        name: "FK_Metrica_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    IdNotificacao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.IdNotificacao);
                    table.ForeignKey(
                        name: "FK_Notificacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkin",
                columns: table => new
                {
                    IdCheckin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHabito = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataCheckin = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkin", x => x.IdCheckin);
                    table.ForeignKey(
                        name: "FK_Checkin_Habito_IdHabito",
                        column: x => x.IdHabito,
                        principalTable: "Habito",
                        principalColumn: "IdHabito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkin_IdHabito",
                table: "Checkin",
                column: "IdHabito");

            migrationBuilder.CreateIndex(
                name: "IX_Habito_IdUsuario",
                table: "Habito",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_IdUsuario",
                table: "Metrica",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_IdUsuario",
                table: "Notificacao",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkin");

            migrationBuilder.DropTable(
                name: "Metrica");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Habito");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
