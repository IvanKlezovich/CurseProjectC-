using CurseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CurseProject.Context;

public class PostgresDbContext : DbContext
{
    private readonly IConfiguration _configuration;

        public PostgresDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost:5432; Database=curs; Username=postgres; Password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Triangle>()
                .HasData(
                    new Triangle { id = 1, name = "wq", a = 1, b = 2, c = 3},
                    new Triangle { id = 2, name = "wq", a = 2, b = 2, c = 2}
                    );
            modelBuilder.Entity<User>()
                .HasData(
                    new User() {Id = 1, Email = "admin@gmail.com", Password = "1111", Role = Role.Admin }
                    );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Triangle> Triangles { get; set; }
}