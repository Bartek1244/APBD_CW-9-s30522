using System.ComponentModel.DataAnnotations;

namespace APBD_CW_9_s30522.DTOs;

public class PrescriptionMedicamentCreateDto
{
    public required int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)] 
    public required string Details { get; set; } = null!;
}