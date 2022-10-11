using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;

public class CreateKeyword:ICommand<long>
{
    public string Title { get; set; }
}