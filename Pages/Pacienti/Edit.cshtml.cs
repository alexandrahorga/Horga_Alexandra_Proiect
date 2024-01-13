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
using System.Security.Policy;

namespace Horga_Alexandra_Proiect.Pages.Pacienti
{
    public class EditModel : CategoriePacientPageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public EditModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            //se va include Author conform cu sarcina de la lab 2
            Pacient = await _context.Pacient
            .Include(b => b.Doc)
            .Include(b => b.Asistent)
            .Include(b => b.CategoriePacient).ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Pacient == null)
            {
                return NotFound();
            }
            PopulareDateCategorie(_context, Pacient);
            var asistentList = _context.Asistent.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["AsistentID"] = new SelectList(asistentList, "ID", "FullName");
            ViewData["DocID"] = new SelectList(_context.Doc, "ID",
           "NumeDoctor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var pacientToUpdate = await _context.Pacient
            .Include(i => i.Doc)
            .Include(i => i.Asistent)
            .Include(i => i.CategoriePacient)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (pacientToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Pacient>(
            pacientToUpdate,
            "Pacient",
            i => i.Nume, i => i.Asistent,
            i => i.Afectiune, i => i.DataConsultatie, i => i.DocID))
            {
                UpdateCategoriiPacient(_context, selectedCategories, pacientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCategoriiPacient(_context, selectedCategories, pacientToUpdate);
            PopulareDateCategorie(_context, pacientToUpdate);
            return Page();
        }
    }
}
