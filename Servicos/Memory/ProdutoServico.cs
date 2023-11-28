using AjCorpWebApp.Models;
using AjCorpWebApp.Servicos;

namespace AjCorpWebApp.Servicos.Memory;

public class ProdutoServico : IProdutoServico
{
    private IList<Produto> _produtos;

    public ProdutoServico() => CarregarListaInicial();

    private void CarregarListaInicial()
    {
        _produtos = new List<Produto>()
        {
            new Produto
        {
            ProdutoId = 1,
            Nome = "Auto Desenvolvimento",
            ImagemUri = "/Imagens/performance.jpg",
            Descricao = "Auto conhecimento aplicado para sua realidade.",
            Duracao= "100 Horas / 6 Meses",
            Inicio= true,
            Preco= 20000

        },
        new Produto
        {
            ProdutoId = 2,
            Nome = "Mentoria",
            ImagemUri = "/Imagens/mentoring.jpg",
            Descricao = "Mentoria para grupos empresariais. Elevamos seu time para o proximo nivel...",
            Duracao= "3 horas",
            Inicio= false,
            Preco= 5000
        },
        new Produto
        {
            ProdutoId = 3,
            Nome = "Seminarios",
            ImagemUri = "/Imagens/seminars.jpg",
            Descricao = "Semirario voltado para feiras e conferencias.",
            Duracao= "45 minutos",
            Inicio= true,
            Preco= 5000

        },
        new Produto
        {
            ProdutoId = 4,
            Nome = "Terapia",
            ImagemUri = "/Imagens/auto-conhecimento.jpg",
            Descricao = "Terapia voltada para alta performance.",
            Duracao= "2.5 horas",
            Inicio= true,
            Preco= 5000

        }

    };
    }

    public IList<Produto> ObterTodos()
        => _produtos;



    public Produto Obter(int id)
    {
        return _produtos.SingleOrDefault(item => item.ProdutoId == id);

        //var ListaProduto = ObterTodos();
        //var Produto = ListaProduto.SingleOrDefault(item => item.ProdutoId == id);
        //return Produto;

    }

    public void Incluir(Produto produto)
    {
        var proximoNumero = _produtos.Max(item => item.ProdutoId) + 1;
        produto.ProdutoId = proximoNumero;
        _produtos.Add(produto);
    }

    public void Alterar(Produto produto)
    {
        var produtoEncontrado = Obter(produto.ProdutoId);
        produtoEncontrado.Nome = produto.Nome;
        produtoEncontrado.Descricao = produto.Descricao;
        produtoEncontrado.Duracao = produto.Duracao;
        produtoEncontrado.Preco = produto.Preco;
        produtoEncontrado.Inicio = produto.Inicio;

    }

    public void Excluir(int id)
    {
        var produtoEncontrado = Obter(id);
        _produtos.Remove(produtoEncontrado);
    }

	public IList<Marca> ObterTodasMarcas()
	{
		return new List<Marca>
			{
				new Marca() {Descricao = "Hipnoze"},
				new Marca() {Descricao = "Consultoria"},
				new Marca() {Descricao = "Palestra"},
			};
	}
}
