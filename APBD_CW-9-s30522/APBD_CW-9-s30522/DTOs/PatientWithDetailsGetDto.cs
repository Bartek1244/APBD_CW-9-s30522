namespace APBD_CW_9_s30522.DTOs;

public class PatientWithDetailsGetDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public ICollection<PrescriptionDetailsGetDto> Prescriptions { get; set; } = null!;
}