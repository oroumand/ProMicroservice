using AppArchSample.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppArchSample.Infra.Data.SQLServer;
public class AppArchContext:DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=AppArchDb;User Id=sa; Password=1qaz!QAZ");
    }
}
