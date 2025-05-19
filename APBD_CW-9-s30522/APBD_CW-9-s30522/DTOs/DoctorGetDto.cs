namespace APBD_CW_9_s30522.DTOs;

public class DoctorGetDto
{  
    public int IdDoctor { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
}