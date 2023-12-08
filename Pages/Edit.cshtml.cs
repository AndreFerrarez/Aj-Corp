using AjCorpWebApp.Models;
using AjCorpWebApp.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjCorpWebApp.Pages;


[Authorize]
public class EditModel : PageModel
    {

	private IProdutoServico _servico;

	public SelectList MarcaOptionTtems { get; set; }

	public EditModel(IProdutoServico produtoServico)
	{
		_servico = produtoServico;
	}

	[BindProperty]
	public Produto Produto { get; set; }
	public void OnGet(int id)
	{
		Produto = _servico.Obter(id);
		MarcaOptionTtems = new SelectList(_servico.ObterTodasMarcas(),
													   nameof(Marca.MarcaId),
													   nameof(Marca.Descricao));
	} 

	public IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}
		// criar novos produtos. dados.

		_servico.Alterar(Produto);

		return RedirectToPage("/Index");
	}

	public IActionResult OnPostDelete()
	{
		_servico.Excluir(Produto.ProdutoId);

		return RedirectToPage("/Index");
	}
}
