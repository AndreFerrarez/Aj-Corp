using AjCorpWebApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjCorpWebApp.Data.Migrations;

/// <inheritdoc />
public partial class AdicionarCargaInicialMarca : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var context = new ProdutoDbContext();
        context.Marca.AddRange(ObterCargaInicial());

        context.SaveChanges();

    }


    private IList<Marca> ObterCargaInicial()
    {
        return new List<Marca>
        {
            new Marca() {Descricao = "Hipnoze"},
            new Marca() {Descricao = "Consultoria"},
            new Marca() {Descricao = "Palestra"},
        };
    }


	}
