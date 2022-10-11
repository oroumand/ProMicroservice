using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;

public class ChangeTitle:ICommand
{
    public int Id { get; set; }
    public string Title { get; set; }
}