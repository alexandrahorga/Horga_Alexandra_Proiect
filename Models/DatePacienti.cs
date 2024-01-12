namespace Horga_Alexandra_Proiect.Models
{
    public class DatePacienti
    {
        public IEnumerable<Pacient> Pacienti { get; set; }
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<CategoriePacient> CategoriePacienti { get; set; }
    }
}
