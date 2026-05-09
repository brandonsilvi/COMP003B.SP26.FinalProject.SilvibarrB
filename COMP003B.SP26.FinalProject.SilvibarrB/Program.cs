// Final Project, Idea is Dog Grooming Service
//Entities will be: Owner, Pet, Groomer, Service, Appointment
//Owner - Id, FName, LName, Email, Phone
//Pet - Id, Name, Species, Breed, Age, OwnerId (fk)
//Groomer - Id, FName, LName, Specialty, HireDate
//Service - Id, Name, Description, Price, ApptDuration
//Id, Appointment Date, Notes, PetId (fk), GroomerId (fk), ServiceId (fk)

//Author: Brandon Silvibarr
//Course: COMP003B ASP.NET Core
//Instructor: Jonathan Cruz
//Purpose: Demonstrate the comprehension and application of MVC, Web API, EF Core, and Middleware

using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Middleware;
using Microsoft.EntityFrameworkCore;


namespace COMP003B.SP26.FinalProject.SilvibarrB;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseMiddleware<RequestTimingMiddleware>();
        app.UseRouting();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
                
                app.MapControllers();
        app.Run();
    }
}