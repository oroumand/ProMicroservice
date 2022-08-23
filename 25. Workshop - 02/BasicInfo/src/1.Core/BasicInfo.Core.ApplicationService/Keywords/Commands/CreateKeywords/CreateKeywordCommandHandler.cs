using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

internal class CreateKeywordCommandHandler : CommandHandler<CreateKeyword, long>
{
    private readonly IKeywordCommandRepository _repository;

    public CreateKeywordCommandHandler(ZaminServices zaminServices,IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreateKeyword request)
    {
        Keyword keyword = new(request.Title);
        await _repository.InsertAsync(keyword);
        await _repository.CommitAsync();
        return Ok(keyword.Id);
    }
}