using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Models
{

    public class Groomer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        public required string Specialty { get; set; }
        
        [Required]
        public required DateTime HireDate { get; set; }
        
        public ICollection<Appointment>? Appointments { get; set; }

    }
}