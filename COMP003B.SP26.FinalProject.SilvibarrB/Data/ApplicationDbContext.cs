using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
        //Manually adding services for dropdown menu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1, Name = "Full Service",
                    Description = "Complete Grooming Package includes all other services for dogs",
                    DurationMinutes = 240, Price = 200
                },
                new Service
                {
                    Id = 2, Name = "Bath",
                    Description = "Full bath; shampoo, conditioner, and fragrance.",
                    DurationMinutes = 120, Price = 125
                },
                new Service
                {
                    Id = 3, Name = "Teeth Cleaning",
                    Description = "Complete dental care package for dogs, includes take home dental chews.",
                    DurationMinutes = 30, Price = 20
                },
                new Service
                {
                    Id = 4, Name = "Nail Grinding/Trimming",
                    Description = "Perfect pet pedicure, for dogs and cats",
                    DurationMinutes = 20, Price = 20
                },
                new Service
                {
                    Id = 5, Name = "Cat Bathing",
                    Description = "Includes Shampoo and Conditioner. Aggressive cats will have dry shampoo used.",
                    DurationMinutes = 120, Price = 100
                },
                new Service
                {
                    Id = 6, Name = "Pet Spa and Color Treatment",
                    Description = "Specialty service includes all items applicable for species along with any style or coloring desired.",
                    DurationMinutes = 360, Price = 500
                }
            );

        }
    }
}