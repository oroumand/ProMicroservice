using BasicInfo.Core.Contracts.Categories.DAL;
using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Domain.Categories.Entities;
using BasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

internal class CreateCategoryCommandHandler : CommandHandler<CreateCategory, long>
{
    private readonly ICategoryCommandRepository _repository;

    public CreateCategoryCommandHandler(ZaminServices zaminServices,ICategoryCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreateCategory request)
    {
        Category category = new(request.Name, request.Title);
        await _repository.InsertAsync(category);
        await _repository.CommitAsync();
        return Ok(category.Id);
    }
}