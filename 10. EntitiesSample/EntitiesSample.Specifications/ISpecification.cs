namespace EntitiesSample.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}
