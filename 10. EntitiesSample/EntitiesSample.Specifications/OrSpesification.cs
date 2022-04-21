namespace EntitiesSample.Specifications;

public class OrSpesification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _first;
    private readonly ISpecification<T> _seccond;

    public OrSpesification(ISpecification<T> first, ISpecification<T> seccond)
    {
        _first = first;
        _seccond = seccond;
    }
    public bool IsSatisfiedBy(T entity)
    {
        return _first.IsSatisfiedBy(entity) || _seccond.IsSatisfiedBy(entity);
    }
}
