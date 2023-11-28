using AjCorpWebApp.Models;
using AjCorpWebApp.Servicos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AjCorpWebApp.Pages;

public class IndexModel : PageModel
{
    private IProdutoServico _servico;
    public IndexModel(IProdutoServico produtoServico)
    {
        _servico = produtoServico;
    }
    public required IList<Produto> ListaProduto { get; set; }

    public void OnGet()
    
    
    {
        //var servico = new ProdutosServico();
        ListaProduto = _servico.ObterTodos();
    } 
};

