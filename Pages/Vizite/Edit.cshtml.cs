using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.Vizite
{
    public class EditModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public EditModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vizita Vizita { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizite == null)
            {
                return NotFound();
            }

            var vizita =  await _context.Vizite.FirstOrDefaultAsync(m => m.ID == id);
            if (vizita == null)
            {
                return NotFound();
            }
            Vizita = vizita;
           ViewData["MembruFamilieID"] = new SelectList(_context.MembruFamilie, "ID", "ID");
           ViewData["PacientID"] = new SelectList(_context.Pacienti, "ID", "ID");
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

            _context.Attach(Vizita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VizitaExists(Vizita.ID))
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

        private bool VizitaExists(int id)
        {
          return (_context.Vizite?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
