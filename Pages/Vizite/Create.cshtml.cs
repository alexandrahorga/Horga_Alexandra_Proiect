using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Horga_Alexandra_Proiect.Pages.Vizite
{
    public class CreateModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public CreateModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var pacientList = _context.Pacient
             .Include(b => b.Asistent)
             .Select(x => new
          {
              x.ID,
              PacientFullName = x.Nume + " - " + x.Asistent.Prenume + " " + x.Asistent.Nume
          });
            ViewData["PacientID"] = new SelectList(pacientList, "ID", "PacientFullName");
            ViewData["MembruFamilieID"] = new SelectList(_context.MembruFamilie, "ID",
           "FullName");
            return Page();
        }

        [BindProperty]
        public Vizita Vizita { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vizite == null || Vizita == null)
            {
                return Page();
            }

            _context.Vizite.Add(Vizita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
