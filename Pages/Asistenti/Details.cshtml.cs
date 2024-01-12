using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.Asistenti
{
    public class DetailsModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public DetailsModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

      public Asistent Asistent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Asistent == null)
            {
                return NotFound();
            }

            var asistent = await _context.Asistent.FirstOrDefaultAsync(m => m.ID == id);
            if (asistent == null)
            {
                return NotFound();
            }
            else 
            {
                Asistent = asistent;
            }
            return Page();
        }
    }
}
