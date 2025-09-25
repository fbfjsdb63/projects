using Microsoft.EntityFrameworkCore;
using task1.model;

namespace task1.data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<user> Users { get; set; } = null!;
        public DbSet<TaskItem> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Email يكون Unique
            modelBuilder.Entity<user>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // العلاقة واحد لمستخدم -> متعدد لمهام
            modelBuilder.Entity<user>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);









        }
        }
}
