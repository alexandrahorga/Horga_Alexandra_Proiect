﻿// <auto-generated />
using System;
using Horga_Alexandra_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Horga_Alexandra_Proiect.Migrations
{
    [DbContext(typeof(Horga_Alexandra_ProiectContext))]
    partial class Horga_Alexandra_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Horga_Alexandra_Proiect.Models.Doc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Doc");
                });

            modelBuilder.Entity("Horga_Alexandra_Proiect.Models.Pacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Afectiune")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataConsultatie")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocID")
                        .HasColumnType("int");

                    b.Property<string>("Doctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DocID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Horga_Alexandra_Proiect.Models.Pacient", b =>
                {
                    b.HasOne("Horga_Alexandra_Proiect.Models.Doc", "Doc")
                        .WithMany("Pacienti")
                        .HasForeignKey("DocID");

                    b.Navigation("Doc");
                });

            modelBuilder.Entity("Horga_Alexandra_Proiect.Models.Doc", b =>
                {
                    b.Navigation("Pacienti");
                });
#pragma warning restore 612, 618
        }
    }
}