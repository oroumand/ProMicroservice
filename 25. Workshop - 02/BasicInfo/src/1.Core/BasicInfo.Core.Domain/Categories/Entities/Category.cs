using BasicInfo.Core.Domain.Categories.Events;
using BasicInfo.Core.Domain.Common.ValueObjects;
using Zamin.Core.Domain.Entities;

namespace BasicInfo.Core.Domain.Categories.Entities;
public class Category : AggregateRoot
{
    public Category(TinyString name, TinyString title)
    {        
        Title = title;
        Name = name;
        AddEvent(new CategoryCreated(BusinessId.Value, title.Value, name.Value));
    }

    public TinyString Title { get; private set; }
    public TinyString Name { get; private set; }
}
