using APBD_CW_9_s30522.Data;
using APBD_CW_9_s30522.DTOs;
using APBD_CW_9_s30522.Exceptions;
using APBD_CW_9_s30522.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_CW_9_s30522.Services;

public interface IDbService
{
    public Task<int> CreatePrescriptionAsync(PrescriptionCreateDto prescription);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<int> CreatePrescriptionAsync(PrescriptionCreateDto prescription)
    {
        if (await data.Doctors.FirstOrDefaultAsync(doc => doc.Id == prescription.IdDoctor) == null)
        {
            throw new NotFoundException($"Doctor of id {prescription.IdDoctor} does not exist");
        }

        if (prescription.Medicaments.Count > 10)
        {
            throw new LimitExceededException(
                $"Too many medicaments ({prescription.Medicaments.Count}) on prescription (limit = 10)");
        }

        if (prescription.Date >= prescription.DueDate)
        {
            throw new LimitExceededException(
                $"Prescription date {prescription.Date} is later then due date {prescription.DueDate}");
        }

        foreach (var medicament in prescription.Medicaments)
        {
            if (await data.Medicaments.FirstOrDefaultAsync(med => med.Id == medicament.IdMedicament) == null)
            {
                throw new NotFoundException($"Medicament of id {medicament.IdMedicament} does not exist");
            }
        }
        
        var transaction = await data.Database.BeginTransactionAsync();

        try
        {
            
            var correspondingPatient =
                await data.Patients.FirstOrDefaultAsync(pat => pat.Id == prescription.Patient.IdPatient);
        
            if (correspondingPatient != null)
            {
                if (correspondingPatient.FirstName != prescription.Patient.FirstName ||
                    correspondingPatient.LastName != prescription.Patient.LastName ||
                    correspondingPatient.Birthdate != prescription.Patient.Birthdate)
                {
                    throw new DataMissMatchException($"Patient data mismatch");
                }
            }
            else
            {
                correspondingPatient = new Patient
                {
                    FirstName = prescription.Patient.FirstName,
                    LastName = prescription.Patient.LastName,
                    Birthdate = prescription.Patient.Birthdate,
                };

                await data.Patients.AddAsync(correspondingPatient);
                await data.SaveChangesAsync();
            }

            var createdPrescription = new Prescription
            {
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                IdPatient = correspondingPatient.Id,
                IdDoctor = prescription.IdDoctor,
                Patient = correspondingPatient,
                Doctor = await data.Doctors.FirstAsync(doc => doc.Id == prescription.IdDoctor)
            };

            await data.Prescriptions.AddAsync(createdPrescription);
            await data.SaveChangesAsync();

            foreach (var medicament in prescription.Medicaments)
            {
                await data.PrescriptionMedicaments.AddAsync(new PrescriptionMedicament
                {
                    IdMedicament = medicament.IdMedicament,
                    IdPrescription = createdPrescription.Id,
                    Dose = medicament.Dose,
                    Details = medicament.Details,
                    Medicament = await data.Medicaments.FirstAsync(med => med.Id == medicament.IdMedicament),
                    Prescription = createdPrescription
                });
            }

            await data.SaveChangesAsync();
            await transaction.CommitAsync();

            return createdPrescription.Id;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}