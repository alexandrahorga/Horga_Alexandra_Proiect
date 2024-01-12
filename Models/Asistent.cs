namespace Horga_Alexandra_Proiect.Models
{
    public class Asistent
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }
        public ICollection<Pacient>? Pacienti { get; set; }
    }
}
