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
    public class DeleteModel : PageModel
    {
        private readonly Bibliotheek.Data.BibliotheekContext _context;

        public DeleteModel(Bibliotheek.Data.BibliotheekContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Boek Boek { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Boek == null)
            {
                return NotFound();
            }

            var boek = await _context.Boek.FirstOrDefaultAsync(m => m.Boek_ID == id);

            if (boek == null)
            {
                return NotFound();
            }
            else 
            {
                Boek = boek;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Boek == null)
            {
                return NotFound();
            }
            var boek = await _context.Boek.FindAsync(id);

            if (boek != null)
            {
                Boek = boek;
                _context.Boek.Remove(Boek);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
