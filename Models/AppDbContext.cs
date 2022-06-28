using BlazorWasmPilet.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmPilet.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<PatientInfo> patients { get; set; }

        public DbSet<HealthCareProvider> healthCareProviders { get; set; }


        public DbSet<HealthCarePractitioner> healthCarePractitioners { get; set; }

        public DbSet<HealthInsuranceInfo> healthInsuranceInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed HealthCareProvider Table

            modelBuilder.Entity<HealthCareProvider>().HasKey(p => p.ProviderId);
            modelBuilder.Entity<HealthCareProvider>().HasData(new HealthCareProvider
            {
                ProviderId = 1,
                Description = "Baptist HealthCare has everything you need",
                location = "Lousiville",
                Name = "Baptist HealthCare",
                PhoneNumber = "502-111-2222"
            });

            modelBuilder.Entity<HealthCareProvider>().HasData(new HealthCareProvider
            {
                ProviderId = 2,
                Description = "UoFL Take cares of your education, health and your well being",
                location = "Lousiville",
                Name = "UoFL Health Care",
                PhoneNumber = "502-111-3333"
            });

            modelBuilder.Entity<HealthCareProvider>().HasData(new HealthCareProvider
            {
                ProviderId = 3,
                Description = "Norton's Everything You need",
                location = "Lousiville",
                Name = "Norton Health Care",
                PhoneNumber = "502-111-4444"
            });

            // Seed Healthcare Practioners

            modelBuilder.Entity<HealthCarePractitioner>().HasKey(p => p.PractitionerId);

            modelBuilder.Entity<HealthCarePractitioner>().HasData(new HealthCarePractitioner { PractitionerId = 1, Name = "Sheema Mehboob", 
                Designation = "Medical Director",
               ProviderId = 2 
            });

            modelBuilder.Entity<HealthCarePractitioner>().HasData(new HealthCarePractitioner
            {
                PractitionerId = 2,
                Name = "Danish",
                Designation = "Physical Therapist",               
                ProviderId = 1
            });

            modelBuilder.Entity<PatientInfo>().HasKey(p => p.PatientId);

            // Seed Patient Info 
            modelBuilder.Entity<PatientInfo>().HasData(new PatientInfo { PatientId = 1, Age = 39, Gender = "Male", PatientLastName = "John",
                PatientFirstName = "Dervik", Email = "john.dervik@gmail.com", PhoneNumber = "502-123-4567" });

            modelBuilder.Entity<PatientInfo>().HasData(new PatientInfo
            {
                PatientId = 2,
                Age = 49,
                Gender = "Female",
                PatientLastName = "Kareena",
                PatientFirstName = "Kapoor",
                Email = "Kareena.Kapoor@gmail.com",
                PhoneNumber = "502-123-4568"
            });

            modelBuilder.Entity<HealthInsuranceInfo>().HasKey(p => p.InsuranceId);
        }
    }
}
