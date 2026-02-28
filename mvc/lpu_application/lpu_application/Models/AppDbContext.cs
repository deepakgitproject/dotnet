using Microsoft.EntityFrameworkCore;

namespace lpu_application.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        // ✅ THIS FIXES THE TRIGGER ERROR
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable(tb => tb.HasTrigger("trg_GenerateRegNo"));
        }
    }
}