using AjCorpWebApp.Models;
using AjCorpWebApp.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AjCorpWebApp.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {

		private IProdutoServico _servico;
        public SelectList MarcaOptionTtems { get; set; }


        public CreateModel(IProdutoServico produtoServico)
		{
			_servico = produtoServico;
		}

        public void OnGet()
        {
            MarcaOptionTtems = new SelectList(_servico.ObterTodasMarcas(),
                                                        nameof(Marca.MarcaId),
                                                        nameof(Marca.Descricao));
        }


        [BindProperty]
        public Produto Produto { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // criar novos produtos. dados.

            _servico.Incluir(Produto);

            return RedirectToPage("/Index");
        }
    }

  
}


