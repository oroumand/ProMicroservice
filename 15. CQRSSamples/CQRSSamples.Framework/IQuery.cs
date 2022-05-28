namespace CQRSSamples.Framework;
public interface IQuery
{
}
public interface IQueryHandler<TQuery,TQueryResult> where TQuery : IQuery
{
    Task Handle(IQuery query);
}
