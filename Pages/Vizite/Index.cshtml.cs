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
    public class IndexModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public IndexModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Vizita> Vizita { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vizite != null)
            {
                Vizita = await _context.Vizite
                    .Include(v => v.Pacient)
                        .ThenInclude(b => b.Asistent)
                .Include(v => v.MembruFamilie).ToListAsync();

            }
        }
    }
}
