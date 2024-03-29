﻿using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
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
        public int? DocID { get; set; }
        public Doc? Doc{ get; set; }
        public ICollection<CategoriePacient>? CategoriePacient { get; set; }
        public int? AsistentID { get; set; }
        [Display(Name = "Nume Asistent ")]

        public Asistent? Asistent { get; set; }
        public int? VizitaID { get; set; }
        public Vizita? Vizia { get; set; }

    }
}
