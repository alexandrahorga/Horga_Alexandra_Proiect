using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Horga_Alexandra_Proiect.Models
{
    public class Vizita
    {
        public int ID { get; set; }
        public int? MembruFamilieID { get; set; }
        public MembruFamilie? MembruFamilie { get; set; }
        public int? PacientID { get; set; }
        public Pacient? Pacient { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataVizita { get; set; }
    }
}
