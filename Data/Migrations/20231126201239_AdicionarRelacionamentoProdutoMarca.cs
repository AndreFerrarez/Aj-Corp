using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjCorpWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentoProdutoMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Marca_MarcaId",
                table: "Produto",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Marca_MarcaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Produto");
        }
    }
}
