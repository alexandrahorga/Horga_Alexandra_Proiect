using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Data
{
    public class Horga_Alexandra_ProiectContext : DbContext
    {
        public Horga_Alexandra_ProiectContext (DbContextOptions<Horga_Alexandra_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Horga_Alexandra_Proiect.Models.Pacient> Pacient { get; set; } = default!;
    }
}
