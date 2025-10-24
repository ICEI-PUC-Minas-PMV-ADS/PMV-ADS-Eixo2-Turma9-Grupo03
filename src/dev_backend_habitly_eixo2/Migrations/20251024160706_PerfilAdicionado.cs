using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dev_backend_habitly_eixo2.Migrations
{
    public partial class PerfilAdicionado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Passo 1: Remover a chave primária antiga e a coluna IdUsuario da tabela Usuarios
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Usuarios");

            // Passo 2: Recriar a coluna IdUsuario como INT IDENTITY e definir como chave primária
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "IdUsuario");

            // Passo 3: Adicionar a nova coluna Perfil
            migrationBuilder.AddColumn<byte>(
                name: "Perfil",
                table: "Usuarios",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Notificacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Metricas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Habitos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Notificacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Metricas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Habitos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
