using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bibliotheek.Data;
using Bibliotheek.Datamodels;

namespace Bibliotheek.Pages.Boeken
{
    public class EditModel : PageModel
    {
        private readonly Bibliotheek.Data.BibliotheekContext _context;
        public EditModel(Bibliotheek.Data.BibliotheekContext context)
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

            var boek =  await _context.Boek.FirstOrDefaultAsync(m => m.Boek_ID == id);
            if (boek == null)
            {
                return NotFound();
            }
            Boek = boek;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Boek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoekExists(Boek.Boek_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BoekExists(int id)
        {
          return (_context.Boek?.Any(e => e.Boek_ID == id)).GetValueOrDefault();
        }
    }
}
