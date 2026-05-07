using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Models
{

    public class Appointment
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime AppointmentDate { get; set; }
        
        public required string? Notes { get; set; }
        
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
        
        public int GroomerId { get; set; }
        public Groomer? Groomer { get; set; }
        
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

    }
}