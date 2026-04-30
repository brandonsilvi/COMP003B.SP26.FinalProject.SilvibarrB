// Final Project, Idea is Dog Grooming Service
//Entities will be: Owner, Pet, Groomer, Service, Appointment
//Owner - Id, FName, LName, Email, Phone
//Pet - Id, Name, Species, Breed, Age, OwnerId (fk)
//Groomer - Id, FName, LName, Specialty, HireDate
//Service - Id, Name, Description, Price,4 ApptDuration
//Id, Appointment Date, Notes, PetId (fk), GroomerId (fk), ServiceId (fk)



namespace COMP003B.SP26.FinalProject.SilvibarrB;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}