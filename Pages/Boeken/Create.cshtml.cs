using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bibliotheek.Data;
using Bibliotheek.Datamodels;

namespace Bibliotheek.Pages.Boeken
{
    public class CreateModel : PageModel
    {
        private readonly Bibliotheek.Data.BibliotheekContext _context;

        public CreateModel(Bibliotheek.Data.BibliotheekContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Boek Boek { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Boek == null || Boek == null)
            {
                return Page();
            }

            _context.Boek.Add(Boek);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
