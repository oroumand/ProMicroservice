using BasicInfo.Core.Contracts.Categories.DAL;
using BasicInfo.Core.Domain.Categories.Entities;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace BasicInfo.Infra.Data.Sql.Commands.Categories;
public class CategoryCommandRepository : BaseCommandRepository<Category, BasicInfoCommandDbContext>,
        ICategoryCommandRepository
{
    public CategoryCommandRepository(BasicInfoCommandDbContext dbContext) : base(dbContext)
    {
    }
}
