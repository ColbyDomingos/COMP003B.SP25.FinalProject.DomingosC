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

        public DbSet<COMP003B.SP25.FinalProject.DomingosC.Models.BookingMechanic> BookingMechanics { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder) //when the model is creating
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceType>()
                .Property(st => st.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<BookingMechanic>()
                .HasKey(bm => new { bm.BookingId, bm.MechanicId });

            modelBuilder.Entity<BookingMechanic>()
                .HasOne(bm => bm.Booking)
                .WithMany(b => b.BookingMechanics)
                .HasForeignKey(bm => bm.BookingId);

            modelBuilder.Entity<BookingMechanic>()
                .HasOne(bm => bm.Mechanic)
                .WithMany(m => m.BookingMechanics)
                .HasForeignKey(bm => bm.MechanicId);
        }
       
    }
}
