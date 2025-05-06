using COMP003B.SP25.FinalProject.DomingosC.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.DomingosC.Data
{
    public class ApplicationDbContext : DbContext //inherits from DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; } //Gets all required fields for the database to connect all the puzzle pieces together
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
    }
}
