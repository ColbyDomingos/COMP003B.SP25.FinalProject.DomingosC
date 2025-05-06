using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.DomingosC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingMechanic>()
                .HasKey(bm => new { bm.BookingId, bm.MechanicId });
        }
    }
}
