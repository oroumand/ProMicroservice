using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.DAL;
using BasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.ChangeTitles;

internal class ChangeTitleCommandHandler : CommandHandler<ChangeTitle>
{
    private readonly IKeywordCommandRepository _repository;

    public ChangeTitleCommandHandler(ZaminServices zaminServices, IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult> Handle(ChangeTitle request)
    {

        Keyword keyword = await _repository.GetGraphAsync(request.Id);
        if (keyword == null)
        {
            AddMessage("ObjectNotFount", nameof(Keyword));
            return Result(Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.NotFound);
        }
        keyword.ChangeTitle(request.Title);
        await _repository.CommitAsync();
        return Ok();
    }
}