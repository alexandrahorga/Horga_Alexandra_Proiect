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
        public DbSet<Pacient> Pacienti { get; set; }
        public DbSet<Vizita> Vizite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship between Pacient and Vizita
            modelBuilder.Entity<Pacient>()
                .HasOne(p => p.Vizia)
                .WithOne(v => v.Pacient)
                .HasForeignKey<Vizita>(v => v.PacientID);
        }
        public Horga_Alexandra_ProiectContext (DbContextOptions<Horga_Alexandra_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Horga_Alexandra_Proiect.Models.Pacient> Pacient { get; set; } = default!;

        public DbSet<Horga_Alexandra_Proiect.Models.Doc>? Doc { get; set; }

        public DbSet<Horga_Alexandra_Proiect.Models.Categorie>? Categorie { get; set; }

        public DbSet<Horga_Alexandra_Proiect.Models.Asistent>? Asistent { get; set; }

        public DbSet<Horga_Alexandra_Proiect.Models.MembruFamilie>? MembruFamilie { get; set; }
    }
}
