using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;

public class CreateCategory:ICommand<long>
{
    public string Title { get; set; }
    public string Name { get; set; }
}