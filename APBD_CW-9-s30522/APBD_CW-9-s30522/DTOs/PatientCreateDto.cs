using System.ComponentModel.DataAnnotations;

namespace APBD_CW_9_s30522.DTOs;

public class PatientCreateDto
{
    public required int IdPatient { get; set; }
    
    [MaxLength(100)]
    public required string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public required string LastName { get; set; } = null!;
    
    public required DateTime Birthdate { get; set; }
}