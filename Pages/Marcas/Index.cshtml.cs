using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AjCorpWebApp.Data;
using AjCorpWebApp.Models;

namespace AjCorpWebApp.Pages.Marcas
{
    public class IndexModel : PageModel
    {
        private readonly AjCorpWebApp.Data.ProdutoDbContext _context;

        public IndexModel(AjCorpWebApp.Data.ProdutoDbContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Marca != null)
            {
                Marca = await _context.Marca.ToListAsync();
            }
        }
    }
}
