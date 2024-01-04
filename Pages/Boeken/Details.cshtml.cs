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
    public class DetailsModel : PageModel
    {
        private readonly Bibliotheek.Data.BibliotheekContext _context;

        public DetailsModel(Bibliotheek.Data.BibliotheekContext context)
        {
            _context = context;
        }

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
    }
}
