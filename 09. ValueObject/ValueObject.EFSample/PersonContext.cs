using Microsoft.EntityFrameworkCore;

namespace ValueObject.EFSample;

public class PersonContext:DbContext
{
    public DbSet<Person> People{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=PersonDb; User Id=sa; Password=1qaz!QAZ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().OwnsOne(c => c.FirstName);
        modelBuilder.Entity<Person>().Property(c => c.LastName).HasConversion(c => c.Value, c => new LastName(c));
    }
}