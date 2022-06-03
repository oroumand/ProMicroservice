using Earth.Core.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain.People.Entities;
using Earth.Utilities;

namespace Earth.Samples.Core.ApplicationServices.People.Commands.CreatePersonHandlers;

internal class CreatePersonHandler : CommandHandler<CreatePerson, long>
{
    private readonly IPersonCommandRepository _repository;

    public CreatePersonHandler(ZaminServices zaminServices, IPersonCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreatePerson request)
    {
        Person person = new(new(request.FirstName), new(request.LastName));
        await _repository.InsertAsync(person);
        await _repository.CommitAsync();

        return Ok(person.Id);
    }
}