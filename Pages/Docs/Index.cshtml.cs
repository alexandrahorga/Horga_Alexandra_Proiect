using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Data;
using Horga_Alexandra_Proiect.Models;
using System.Security.Policy;
using Horga_Alexandra_Proiect.Models.ViewModels;

namespace Horga_Alexandra_Proiect.Pages.Docs
{
    public class IndexModel : PageModel
    {
        private readonly Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext _context;

        public IndexModel(Horga_Alexandra_Proiect.Data.Horga_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Doc> Doc { get;set; } = default!;

        public DocIndexData DocData { get; set; }
        public int DocID { get; set; }
        public int PacientID { get; set; }
        public async Task OnGetAsync(int? id, int? pacientID)
        {
            DocData = new DocIndexData();
            DocData.Docs = await _context.Doc
            .Include(i => i.Pacienti)
            .ThenInclude(c => c.Asistent)
            .OrderBy(i => i.NumeDoctor)
            .ToListAsync();
            if (id != null)
            {
                DocID = id.Value;
                Doc doc = DocData.Docs
                .Where(i => i.ID == id.Value).Single();
                DocData.Pacienti = doc.Pacienti;
            }
        }
    }
}
