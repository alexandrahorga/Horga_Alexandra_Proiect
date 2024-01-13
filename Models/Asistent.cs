using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Horga_Alexandra_Proiect.Models
{
    public class Asistent
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Pacient>? Pacienti { get; set; }
    }
}
