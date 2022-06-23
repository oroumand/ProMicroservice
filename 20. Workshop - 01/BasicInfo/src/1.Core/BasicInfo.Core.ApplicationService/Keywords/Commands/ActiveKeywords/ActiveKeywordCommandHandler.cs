using BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.ChangeTitles;

internal class ActiveKeywordCommandHandler : CommandHandler<ActiveKeyword>
{
    private readonly IKeywordCommandRepository _repository;

    public ActiveKeywordCommandHandler(ZaminServices zaminServices, IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult> Handle(ActiveKeyword request)
    {

        Keyword keyword = await _repository.GetGraphAsync(request.Id);
        if (keyword == null)
        {
            AddMessage("ObjectNotFount", nameof(Keyword));
            return Result(Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.NotFound);
        }
        keyword.Active();
        await _repository.CommitAsync();
        return Ok();
    }
}