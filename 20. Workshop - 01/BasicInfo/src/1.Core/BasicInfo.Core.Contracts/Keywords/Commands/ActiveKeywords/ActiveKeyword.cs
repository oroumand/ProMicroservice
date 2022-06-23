using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords;

public class ActiveKeyword : ICommand
{
    public int Id { get; set; }
}