using izySick.Models;
using Microsoft.EntityFrameworkCore;

namespace IzySickAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Docteur> Docteurss { get; set; }
        public DbSet<Patient> Patientss { get; set; }
        public DbSet<Receptionniste> Receptionnistess { get; set; }
        public DbSet<Medicaments> Medicamentss { get; set; }
        public DbSet<MedicamentVendu> MedicamentVenduss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
            modelBuilder.Entity<Docteur>().HasKey(d => d.DocteurId);
            //modelBuilder.Entity<Docteur>().HasMany(d => d.Patients).WithOne(p => p.DocteurTraitant);
            modelBuilder.Entity<Receptionniste>().HasKey(r => r.ReceptionnisteId);
            modelBuilder.Entity<Medicaments>().HasKey(m => m.MedicamentsId);
            modelBuilder.Entity<MedicamentVendu>().HasKey(md => md.MedicamentVenduId);

        }
    }
}
