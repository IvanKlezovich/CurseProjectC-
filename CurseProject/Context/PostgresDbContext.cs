using CurseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CurseProject.Context;

public class PostgresDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost:5432; Database=curs; Username=postgres; Password=root");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Triangle> Triangles { get; set; }
}