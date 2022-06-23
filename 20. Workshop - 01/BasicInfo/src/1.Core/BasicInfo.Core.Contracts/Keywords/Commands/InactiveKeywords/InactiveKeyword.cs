using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.InactiveKeywords;

public class InactiveKeyword : ICommand
{
    public int Id { get; set; }
}