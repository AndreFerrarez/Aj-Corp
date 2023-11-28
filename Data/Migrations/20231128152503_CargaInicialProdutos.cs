using Microsoft.EntityFrameworkCore.Migrations;
using AjCorpWebApp.Models;

#nullable disable

namespace AjCorpWebApp.Data.Migrations;

/// <inheritdoc />
public partial class CargaInicialProdutos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
			var context = new ProdutoDbContext();
			context.Produto.AddRange(ObterCargaInicial());

			context.SaveChanges();
		}

    private IList<Produto> ObterCargaInicial()
    {
		return  new List<Produto>()
		{
			new Produto
		{
			
			Nome = "Auto Desenvolvimento",
			ImagemUri = "/Imagens/performance.jpg",
			Descricao = "Auto conhecimento aplicado para sua realidade.",
			Duracao= "100 Horas / 6 Meses",
			Inicio= true,
			Preco= 20000

		},
		new Produto
		{
			
			Nome = "Mentoria",
			ImagemUri = "/Imagens/mentoring.jpg",
			Descricao = "Mentoria para grupos empresariais. Elevamos seu time para o proximo nivel...",
			Duracao= "3 horas",
			Inicio= false,
			Preco= 5000
		},
		new Produto
		{
			
			Nome = "Seminarios",
			ImagemUri = "/Imagens/seminars.jpg",
			Descricao = "Semirario voltado para feiras e conferencias.",
			Duracao= "45 minutos",
			Inicio= true,
			Preco= 5000

		},
		new Produto
		{
			
			Nome = "Terapia",
			ImagemUri = "/Imagens/auto-conhecimento.jpg",
			Descricao = "Terapia voltada para alta performance.",
			Duracao= "2.5 horas",
			Inicio= true,
			Preco= 5000

		}

	};
	}

	}
