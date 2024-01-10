namespace Horga_Alexandra_Proiect.Models
{
    public class Doc
    {
        public int ID { get; set; }
        public string NumeDoctor { get; set; }
        public ICollection<Pacient>? Pacienti { get; set; }
    }
}
