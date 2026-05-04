using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Models
{

    public class Pet
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public string Species { get; set; }
        
        public string? Breed { get; set; }
        
        [Range(0, 30)]
        public int Age { get; set; }
        
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}