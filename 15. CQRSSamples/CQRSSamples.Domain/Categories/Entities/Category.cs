using CQRSSamples.Domain.Categories.Events;
using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Categories.Entities;

public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public Category(string title)
    {
        Title = title;
        AddEvent(new CategoryCreated(title));
    }

    public void SetName(string title)
    {
        Title = title;
        AddEvent(new NameChanged(Id, title));
    }
}
