using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure;

public class DBContext : DbContext
{
    public DbSet<Result> Results { get; set; }
    public DbSet<Standart> Standarts { get; set; }
    public DbSet<Student> Students { get; set; }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}