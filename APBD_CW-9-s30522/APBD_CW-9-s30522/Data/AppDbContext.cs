using APBD_CW_9_s30522.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CW_9_s30522.Data;

public class AppDbContext : DbContext
{

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var patients = new List<Patient>
        {
            new()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Psikutas",
                Birthdate = DateTime.Parse("01/01/1999 00:00:00 AM"),
            },
            new()
            {
                Id = 2,
                FirstName = "Andrzej",
                LastName = "Andrzejewski",
                Birthdate = DateTime.Parse("01/01/1999 00:00:00 AM"),
            },
        };

        var doctors = new List<Doctor>
        {
            new()
            {
                Id = 1,
                FirstName = "Kacper",
                LastName = "Kacperowski",
                Email = "Kacperowski120@email.emailowo"
            }
        };

        var prescriptions = new List<Prescription>
        {
            new()
            {
                Id = 1,
                Date = DateOnly.Parse("19/05/2025"),
                DueDate = DateOnly.Parse("19/06/2025"),
                IdPatient = 1,
                IdDoctor = 1
            },
            new()
            {
                Id = 2,
                Date = DateOnly.Parse("19/05/2025"),
                DueDate = DateOnly.Parse("19/06/2025"),
                IdPatient = 1,
                IdDoctor = 1
            },
            new()
            {
                Id = 3,
                Date = DateOnly.Parse("19/05/2025"),
                DueDate = DateOnly.Parse("19/06/2025"),
                IdPatient = 2,
                IdDoctor = 1
            }
        };

        var medicaments = new List<Medicament>
        {
            new()
            {
                Id = 1,
                Name = "Piwo",
                Type = "Napoj",
                Description = "Pyszne"
            },
            new()
            {
                Id = 2,
                Name = "Ziola Lecznicze",
                Type = "Do Palenia",
                Description = "Też niezle"
            },
        };

        var prescriptionMedicaments = new List<PrescriptionMedicament>
        {
            new()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 10,
                Details = "Dużo"
            },
            new()
            {
                IdMedicament = 1,
                IdPrescription = 2,
                Dose = 1,
                Details = "Okej"
            },
            new()
            {
                IdMedicament = 1,
                IdPrescription = 3,
                Dose = 5,
                Details = "Lecimy"
            },
        };

        modelBuilder.Entity<Patient>().HasData(patients);
        modelBuilder.Entity<Doctor>().HasData(doctors);
        modelBuilder.Entity<Prescription>().HasData(prescriptions);
        modelBuilder.Entity<Medicament>().HasData(medicaments);
        modelBuilder.Entity<PrescriptionMedicament>().HasData(prescriptionMedicaments);
    }
    
}