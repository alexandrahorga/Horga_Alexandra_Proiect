using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.Docs
{
    public class DeleteModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public DeleteModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Doc Doc { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Doc == null)
            {
                return NotFound();
            }

            var doc = await _context.Doc.FirstOrDefaultAsync(m => m.ID == id);

            if (doc == null)
            {
                return NotFound();
            }
            else 
            {
                Doc = doc;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Doc == null)
            {
                return NotFound();
            }
            var doc = await _context.Doc.FindAsync(id);

            if (doc != null)
            {
                Doc = doc;
                _context.Doc.Remove(Doc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
