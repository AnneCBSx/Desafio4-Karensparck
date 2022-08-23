using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.Biblioteca.Infra.Migrations
{
    public partial class AddEmprestimos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEmprestimo = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emprestimos_livros_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimos_usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_IdLivro",
                table: "emprestimos",
                column: "IdLivro");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_IdUsuario",
                table: "emprestimos",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimos");
        }
    }
}
