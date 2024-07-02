using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Emodiario.Data.Migrations
{
    public partial class UpdateAvaliacaoPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Avaliacoes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Avaliacoes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                columns: new[] { "IdUsuario", "IdCategoria" });
        }
    }
}
