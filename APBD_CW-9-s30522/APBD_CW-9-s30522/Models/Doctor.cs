using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW_9_s30522.Models;

public class Doctor
{
    [Key]
    [Column("IdDoctor")]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)] 
    public string Email { get; set; } = null!;
}