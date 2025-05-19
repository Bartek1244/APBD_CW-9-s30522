namespace APBD_CW_9_s30522.DTOs;

public class PrescriptionDetailsGetDto
{
    public int IdPrescription { get; set; }
    public DoctorGetDto Doctor { get; set; } = null!;
    public ICollection<MedicamentGetDto> Medicaments { get; set; } = null!;
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
}