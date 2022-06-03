using Earth.Samples.Core.Domain.People.Entities;
using Earth.Samples.Core.Domain.People.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Earth.Samples.Infra.Data.Sql.Commands.People.Config;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(c => c.FirstName).HasConversion(c => c.Value, c => new FirstName(c));
        builder.Property(c => c.LastName).HasConversion(c => c.Value, c => new LastName(c));
    }
}