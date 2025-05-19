namespace APBD_CW_9_s30522.DTOs;

public class PrescriptionCreateDto
{
    public required PatientCreateDto Patient { get; set; }
    
    public required ICollection<PrescriptionMedicamentCreateDto> Medicaments { get; set; }
    
    public required int IdDoctor { get; set; }
    
    public required DateOnly Date { get; set; }
    
    public required DateOnly DueDate { get; set; }
}