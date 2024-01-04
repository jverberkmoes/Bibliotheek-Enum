using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bibliotheek.Data;
using Bibliotheek.Datamodels;

namespace Bibliotheek.Pages.Boeken
{
    public class IndexModel : PageModel
    {
        private readonly Bibliotheek.Data.BibliotheekContext _context;

        public IndexModel(Bibliotheek.Data.BibliotheekContext context)
        {
            _context = context;
        }

        public IList<Boek> Boek { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Boek != null)
            {
                Boek = await _context.Boek.ToListAsync();
            }
        }
    }
}
