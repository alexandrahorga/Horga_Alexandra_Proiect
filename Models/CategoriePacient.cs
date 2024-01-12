namespace Horga_Alexandra_Proiect.Models
{
    public class CategoriePacient
    {
        public int ID { get; set; }
        public int PacientID { get; set; }
        public Pacient Pacient { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }

        internal static bool Contains(int iD)
        {
            throw new NotImplementedException();
        }

        internal static bool Contains(HashSet<int> pacientCategorii, int iD)
        {
            throw new NotImplementedException();
        }
    }
}
