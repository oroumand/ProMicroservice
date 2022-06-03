using Earth.Core.Contracts.Data.Commands;
using Earth.Samples.Core.Domain.People.Entities;

namespace Earth.Samples.Core.Contracts.People.Commands;
public interface IPersonCommandRepository: ICommandRepository<Person>
{
}
