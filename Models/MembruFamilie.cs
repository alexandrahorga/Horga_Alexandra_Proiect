using System.ComponentModel.DataAnnotations;

namespace Horga_Alexandra_Proiect.Models
{
    public class MembruFamilie
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Vizita>? Vizita { get; set; }
    }
}
