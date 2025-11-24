using Microsoft.EntityFrameworkCore;
using TestBackEnd.Models;

namespace TestBackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .OwnsMany(p => p.Skills, a =>
                {
                    a.WithOwner().HasForeignKey("PersonId");

                    a.Property<int>("Id");
                    a.HasKey("Id");
                });
        }
    }
}
