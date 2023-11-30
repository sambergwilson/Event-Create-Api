using EventCreateDataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace EventCreateDataAccess.Context
{
    public class EventCreateDbContext : DbContext
    {
        public EventCreateDbContext(DbContextOptions options) : base(options)
        {

        }

        public EventCreateDbContext()
        {

        }

        public DbSet<EventCreateModel> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GMO2ILF\\SQLEXPRESS02;Database=EventCreate;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCreateModel>(
                entity =>
                {
                    entity.ToTable("EventCreate");
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id);
                    entity.Property(e => e.EventName);
                    entity.Property(e => e.EventDescription);
                });
        }
    }
}
