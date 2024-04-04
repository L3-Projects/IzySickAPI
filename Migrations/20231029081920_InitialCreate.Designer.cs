﻿// <auto-generated />
using System;
using IzySickAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IzySickAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231029081920_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("izySick.Models.Docteur", b =>
                {
                    b.Property<int>("DocteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocteurId"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexe")
                        .HasColumnType("int");

                    b.Property<string>("Specialisation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocteurId");

                    b.ToTable("Docteurss");
                });

            modelBuilder.Entity("izySick.Models.MedicamentVendu", b =>
                {
                    b.Property<int>("MedicamentVenduId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentVenduId"));

                    b.Property<int>("MedicamentsId")
                        .HasColumnType("int");

                    b.Property<int?>("QuantiteVendu")
                        .HasColumnType("int");

                    b.HasKey("MedicamentVenduId");

                    b.HasIndex("MedicamentsId");

                    b.ToTable("MedicamentVenduss");
                });

            modelBuilder.Entity("izySick.Models.Medicaments", b =>
                {
                    b.Property<int>("MedicamentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentsId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NbEnStock")
                        .HasColumnType("int");

                    b.Property<string>("NomMedicament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Prix")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicamentsId");

                    b.ToTable("Medicamentss");
                });

            modelBuilder.Entity("izySick.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Autorisation")
                        .HasColumnType("int");

                    b.Property<string>("Batiment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Chambre")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateHosp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRdv")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocteurId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Etage")
                        .HasColumnType("int");

                    b.Property<int?>("Hospitalise")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("Limite")
                        .HasColumnType("int");

                    b.Property<string>("Maladie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicamentsId")
                        .HasColumnType("int");

                    b.Property<string>("Motif")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexe")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Traitement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Urgence")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("DocteurId");

                    b.HasIndex("MedicamentsId");

                    b.ToTable("Patientss");
                });

            modelBuilder.Entity("izySick.Models.Receptionniste", b =>
                {
                    b.Property<int>("ReceptionnisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceptionnisteId"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Mdp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexe")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceptionnisteId");

                    b.ToTable("Receptionnistess");
                });

            modelBuilder.Entity("izySick.Models.MedicamentVendu", b =>
                {
                    b.HasOne("izySick.Models.Medicaments", null)
                        .WithMany("MedVendu")
                        .HasForeignKey("MedicamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("izySick.Models.Patient", b =>
                {
                    b.HasOne("izySick.Models.Docteur", "DocteurTraitant")
                        .WithMany("Patients")
                        .HasForeignKey("DocteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("izySick.Models.Medicaments", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentsId");

                    b.Navigation("DocteurTraitant");

                    b.Navigation("Medicament");
                });

            modelBuilder.Entity("izySick.Models.Docteur", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("izySick.Models.Medicaments", b =>
                {
                    b.Navigation("MedVendu");
                });
#pragma warning restore 612, 618
        }
    }
}
