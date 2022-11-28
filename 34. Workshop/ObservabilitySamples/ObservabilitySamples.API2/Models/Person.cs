using Microsoft.EntityFrameworkCore;

namespace ObservabilitySamples.API2.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class PeopleContext:DbContext
{
    public PeopleContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
}
