using BasicInfo.Core.Domain.Keywords.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicInfo.Infra.Data.Sql.Commands.Kyewords.Configs;

public class KeywordConfig : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.Property(c => c.Title).HasConversion<KeywordTitleValueConversion>().HasMaxLength(50);
    }
}