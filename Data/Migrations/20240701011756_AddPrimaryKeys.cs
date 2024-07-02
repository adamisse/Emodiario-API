using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emodiario.Data.Migrations
{
    public partial class AddPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Categorias_CategoriaId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_CategoriaId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdCategoria",
                table: "Avaliacoes",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdUsuario",
                table: "Avaliacoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Categorias_IdCategoria",
                table: "Avaliacoes",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_IdUsuario",
                table: "Avaliacoes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Categorias_IdCategoria",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Usuarios_IdUsuario",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_IdCategoria",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_IdUsuario",
                table: "Avaliacoes");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Avaliacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Avaliacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_CategoriaId",
                table: "Avaliacoes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Categorias_CategoriaId",
                table: "Avaliacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Usuarios_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
