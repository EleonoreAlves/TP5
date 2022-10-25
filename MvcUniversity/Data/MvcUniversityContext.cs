using Microsoft.EntityFrameworkCore;
using Models;

namespace MvcUniversity.Data;
public class UniversityContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    public string DbPath { get; private set; }

    public UniversityContext()
    { DbPath = "EFUniversity.db"; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }

}