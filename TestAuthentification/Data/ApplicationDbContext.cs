using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAuthentification.Models;

namespace TestAuthentification.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Medecin> Medecin { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TypeConsultation> TypeConsultation { get; set; }
    }
}