namespace RepositorySamples.Framework;

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
