namespace EntitiesSample.Specifications;

public class AndSpesification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _first;
    private readonly ISpecification<T> _seccond;

    public AndSpesification(ISpecification<T> first, ISpecification<T> seccond)
    {
        _first = first;
        _seccond = seccond;
    }
    public bool IsSatisfiedBy(T entity)
    {
        return _first.IsSatisfiedBy(entity) && _seccond.IsSatisfiedBy(entity);
    }
}
