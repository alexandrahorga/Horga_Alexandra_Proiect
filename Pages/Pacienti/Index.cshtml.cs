using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;
using System.Net;

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
        public object pacient { get; private set; }
        public string NumeSort { get; set; }
        public string AsistentSort { get; set; }
        public DatePacienti PacientD { get; set; }
        public int PacientID { get; set; }
        public int CategorieID { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string searchString)
        {
            PacientD = new DatePacienti();
            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            AsistentSort = sortOrder == "asistent" ? "asistent_desc" : "asistent";

            PacientD.Pacienti = await _context.Pacient
                .Include(b => b.Doc)
                 .Include(b => b.Asistent)
                .Include(b => b.CategoriePacient)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                PacientD.Pacienti = PacientD.Pacienti
                    .Where(s =>
                        s.Asistent != null &&
                        (s.Asistent.Prenume.Contains(searchString) ||
                         s.Asistent.Nume.Contains(searchString) ||
                         s.Nume.Contains(searchString))
                    );
            }

            if (id != null)
            {
                PacientID = id.Value;

                // Use FirstOrDefault to avoid NullReferenceException if no matching Pacient is found
                Pacient pacient = PacientD.Pacienti
                    .Where(i => i.ID == id.Value)
                    .FirstOrDefault();

                if (pacient != null)
                {
                    // Your existing code here...
                    PacientD.Categorie = pacient.CategoriePacient.Select(s => s.Categorie);
                }
            }

            // Rest of your code...
        

            switch (sortOrder)
            {
                case "nume_desc":
                    PacientD.Pacienti = PacientD.Pacienti.OrderByDescending(s =>
                   s.Nume);
                    break;
                case "asistent_desc":
                    PacientD.Pacienti = PacientD.Pacienti.OrderByDescending(s =>
                        s.Asistent != null ? s.Asistent.FullName : null);
                    break;
                case "asistent":
                    PacientD.Pacienti = PacientD.Pacienti.OrderBy(s =>
                        s.Asistent != null ? s.Asistent.FullName : null);
                    break;
                default:
                    PacientD.Pacienti = PacientD.Pacienti.OrderBy(s => s.Nume);
                    break;
            }
        }
    }
}
