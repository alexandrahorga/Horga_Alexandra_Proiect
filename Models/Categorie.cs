namespace Horga_Alexandra_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategoriePacient>? CategoriePacient { get; set; }
    }
}
