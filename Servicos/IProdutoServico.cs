using AjCorpWebApp.Models;

namespace AjCorpWebApp.Servicos;

public interface IProdutoServico
{
	IList<Produto> ObterTodos();
	Produto Obter(int id);
	void Incluir(Produto produto);
	void Alterar(Produto produto);
	void Excluir(int id);

	IList<Marca> ObterTodasMarcas();


}
