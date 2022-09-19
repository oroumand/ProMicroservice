using BasicInfo.Core.Domain.Categories.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace BasicInfo.Core.Contracts.Categories.DAL;
public interface ICategoryCommandRepository : ICommandRepository<Category>
{
}
