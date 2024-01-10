using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Horga_Alexandra_Proiect.Models
{
    public class Pacient
    {
        public int ID { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Display(Name = "Nume Pacient")]

        public string Nume { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Doctor { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Afectiune { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataConsultatie { get; set; }
    }
}
