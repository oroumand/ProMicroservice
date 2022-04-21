namespace EntitiesSample.Specifications;

public class NotSpesification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _first;


    public NotSpesification(ISpecification<T> first)
    {
        _first = first;
    }
    public bool IsSatisfiedBy(T entity)
    {
        return !_first.IsSatisfiedBy(entity);
    }
}