using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Pages.Pacienti
{
    public class IndexModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public IndexModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; } = default!;
        public string NumeSort { get; set; }
        public string AsistentSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            AsistentSort = sortOrder == "asistent" ? "asistent_desc" : "asistent";
            ///if (_context.Pacient != null)
            ///{
            ///Pacient = await _context.Pacient.ToListAsync();
            ///}
            Pacient = await _context.Pacient
                .Include(b => b.Doc)
                .Include(c => c.Asistent)
                .ToListAsync();


        }
    }
}
