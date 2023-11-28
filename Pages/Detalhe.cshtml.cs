

using AjCorpWebApp.Models;
using AjCorpWebApp.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AjCorpWebApp.Pages;

public class DetalheModel : PageModel
{
    private IProdutoServico _servico;
    public DetalheModel(IProdutoServico produtoServico)
    {
        _servico = produtoServico;
    }
    public Models.Produto Produto { get; private set; }
    public Marca Marca { get; private set; }
    public IActionResult OnGet(int id)
    {
        
        Produto = _servico.Obter(id);
        Marca = _servico.ObterTodasMarcas().SingleOrDefault(item => item.MarcaId == Produto.MarcaId);

        if(Produto == null)
        {
            return NotFound();
        }

        return Page();
    }
}
