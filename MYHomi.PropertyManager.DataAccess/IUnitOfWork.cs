using MongoDB.Driver;

namespace MyHomi.PropertyManager.DataAccess
{
    public interface IUnitOfWork
    {
        IMongoCollection<T> GetCollection<T>();
        TTransactionSessionType GetCurrentTransactionSession<TTransactionSessionType>();
        //Task CommitAsync(CancellationToken cancellationToken = default);
        //Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        //Task AbortTransactionAsync(CancellationToken cancellationToken = default);
        object GetSessionId();
    }
}
