using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.MembriFamiliei
{
    public class DeleteModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public DeleteModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MembruFamilie MembruFamilie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MembruFamilie == null)
            {
                return NotFound();
            }

            var membrufamilie = await _context.MembruFamilie.FirstOrDefaultAsync(m => m.ID == id);

            if (membrufamilie == null)
            {
                return NotFound();
            }
            else 
            {
                MembruFamilie = membrufamilie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MembruFamilie == null)
            {
                return NotFound();
            }
            var membrufamilie = await _context.MembruFamilie.FindAsync(id);

            if (membrufamilie != null)
            {
                MembruFamilie = membrufamilie;
                _context.MembruFamilie.Remove(MembruFamilie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
