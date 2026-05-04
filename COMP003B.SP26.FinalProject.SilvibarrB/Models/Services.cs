using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Models
{

    public class Services
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        [Range(0,500)]
        public decimal Price { get; set; }
        
        [Required]
        public int DurationMinutes { get; set; }
        
        public ICollection<Appointment>? Appointments { get; set; }

    }
}