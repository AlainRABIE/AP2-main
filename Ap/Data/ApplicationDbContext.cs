using System;
using ASPBookProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ASPBookProject.Data;

public class ApplicationDbContext : IdentityDbContext<Medecin>
{
    // Nous allons creer un dbset pour chaque table de notre base de donnees
    // Dbset est une classe generique qui represente une table dans la base de donnees
    // Elle est responsable du mapping objet-relationnel
    public DbSet<Patient> Roster { get; set; }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Medecin> Medecins => Set<Medecin>();
    public DbSet<Incompatibilite> Incompatibilites => Set<Incompatibilite>();
    public DbSet<Ordonnance> Ordonnances => Set<Ordonnance>();
    public DbSet<Medicament> Medicaments => Set<Medicament>();
    public DbSet<Antecedent> Antecedents => Set<Antecedent>();
    


    // Constructeur
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Medecin> Medecin {get;set;}
   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Patient>()
        .HasMany(p => p.Incompatibilites)
        .WithMany(i => i.Patients)
        .UsingEntity(j => j.ToTable("IncompatibilitesPatient"));

    modelBuilder.Entity<Patient>()
        .HasMany(p => p.Antecedents)
        .WithMany(a => a.Patients)
        .UsingEntity(j => j.ToTable("AntecedentPatient"));

    modelBuilder.Entity<Antecedent>()
        .HasMany(a => a.Medicaments)
        .WithMany(m => m.Antecedents)
        .UsingEntity(j => j.ToTable("AntecedentMedicament"));

    modelBuilder.Entity<Ordonnance>()
        .HasOne(o => o.Patient)
        .WithOne(p => p.Ordonnance)
        .HasForeignKey<Ordonnance>(o => o.PatientId);

    modelBuilder.Entity<Ordonnance>()
        .HasMany(o => o.Medicaments)
        .WithMany(m => m.Ordonnances)
        .UsingEntity(j => j.ToTable("OrdonnanceMedicament"));

    base.OnModelCreating(modelBuilder);
}

}
