using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.Vizite
{
    public class DetailsModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public DetailsModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

      public Vizita Vizita { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizite == null)
            {
                return NotFound();
            }

            var vizita = await _context.Vizite.FirstOrDefaultAsync(m => m.ID == id);
            if (vizita == null)
            {
                return NotFound();
            }
            else 
            {
                Vizita = vizita;
            }
            return Page();
        }
    }
}
