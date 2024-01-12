using Microsoft.AspNetCore.Mvc.RazorPages;
using Horga_Alexandra_Proiect.Data;
namespace Horga_Alexandra_Proiect.Models
{
    public class CategoriePacientPageModel : PageModel
    {
        public List<DateCategorie> ListaDateCategorie;
        public void PopulareDateCategorie(Horga_Alexandra_ProiectContext context,
        Pacient pacient)
        {
            var toateCategoriile = context.Categorie;
            var pacientCategorii = new HashSet<int>(
            pacient.CategoriePacient.Select(c => c.CategorieID)); //
        ListaDateCategorie = new List<DateCategorie>();
            foreach (var cat in toateCategoriile)
            {
                ListaDateCategorie.Add(new DateCategorie
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Asignat = CategoriePacient.Contains(pacientCategorii, cat.ID)
                });
            }
        }
        public void UpdateCategoriiPacient(Horga_Alexandra_ProiectContext context,
        string[] selectedCategories, Pacient pacientToUpdate)
        {
            if (selectedCategories == null)
            {
                pacientToUpdate.CategoriePacient = new List<CategoriePacient>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var categoriePacient = new HashSet<int>
            (pacientToUpdate.CategoriePacient.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!categoriePacient.Contains(cat.ID))
                    {
                        pacientToUpdate.CategoriePacient.Add(
                        new CategoriePacient
                        {
                            PacientID = pacientToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (categoriePacient.Contains(cat.ID))
                    {
                        CategoriePacient courseToRemove
                        = pacientToUpdate
                        .CategoriePacient
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
