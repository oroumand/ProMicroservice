using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Categories;

public class CategoryCreated:IDomainEvent
{
    public string Title { get;}
    public CategoryCreated(string title)
    {
        Title=title;
    }

}

public class NameChanged : IDomainEvent
{
    public long Id { get; }
    public string Title { get; }
    public NameChanged(long id,string title)
    {
        Title = title;
        Id = id;
    }

}