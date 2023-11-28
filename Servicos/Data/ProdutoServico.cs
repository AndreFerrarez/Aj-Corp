using AjCorpWebApp.Data;
using AjCorpWebApp.Models;

namespace AjCorpWebApp.Servicos.Data;

public class ProdutoServico : IProdutoServico
{
	private ProdutoDbContext _context;
	public ProdutoServico(ProdutoDbContext context)
	{
		_context = context;
	}
	public void Alterar(Produto produto)
	{
		var produtoEncontrado = Obter(produto.ProdutoId);
		produtoEncontrado.Nome = produto.Nome;
		produtoEncontrado.Descricao = produto.Descricao;
		produtoEncontrado.Duracao = produto.Duracao;
		produtoEncontrado.Preco = produto.Preco;
		produtoEncontrado.Inicio = produto.Inicio;
		produtoEncontrado.ImagemUri = produto.ImagemUri;
		produtoEncontrado.MarcaId = produto.MarcaId;

		_context.SaveChanges();
	}

	public void Excluir(int id)
	{
		var produtoEncontrado = Obter(id);
		_context.Produto.Remove(produtoEncontrado);
		_context.SaveChanges();
	}

	public void Incluir(Produto produto)
	{
		_context.Produto.Add(produto);
		_context.SaveChanges();
	}

	public Produto Obter(int id)
	{
		return _context.Produto.SingleOrDefault(item => item.ProdutoId == id);
	}

	public IList<Marca> ObterTodasMarcas()
	{
		return _context.Marca.ToList();
	}

	public IList<Produto> ObterTodos()
	{
		return _context.Produto.ToList();
	}
}
