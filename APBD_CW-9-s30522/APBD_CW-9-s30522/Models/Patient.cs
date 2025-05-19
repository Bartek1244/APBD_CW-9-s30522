using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW_9_s30522.Models;

public class Patient
{
    [Key]
    [Column("IdPatient")]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    public DateTime Birthdate { get; set; }
}