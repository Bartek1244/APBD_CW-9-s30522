using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_CW_9_s30522.Models;

public class Prescription
{
    [Key]
    [Column("IdPrescription")]
    public int Id { get; set; }

    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }

    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; } = null!;
    
}