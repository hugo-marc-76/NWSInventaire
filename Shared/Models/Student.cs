using System.ComponentModel.DataAnnotations;

namespace NWSInventaire.Shared.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }

        [MaxLength(50)]
        public string? StudentFirstName { get; set; }
        
        [MaxLength(50)]
        public string? StudentLastName { get; set; }

        [MaxLength(50)]
        public string? StudentMail { get; set; }

    }
}
