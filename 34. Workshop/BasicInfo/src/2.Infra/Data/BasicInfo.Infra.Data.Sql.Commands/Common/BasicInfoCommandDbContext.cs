using Microsoft.EntityFrameworkCore;
using BasicInfo.Core.Domain.Blogs.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Infra.Data.Sql.Commands.ValueConversions;
using BasicInfo.Core.Domain.Keywords.Entities;
using BasicInfo.Core.Domain.Common.ValueObjects;
using BasicInfo.Core.Domain.Categories.Entities;

namespace BasicInfo.Infra.Data.Sql.Commands.Common
{
    public class BasicInfoCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BasicInfoCommandDbContext(DbContextOptions<BasicInfoCommandDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
            configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
            configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
            configurationBuilder.Properties<TinyString>().HaveConversion<TinyStringValueConversion>();

        }
    }
}
