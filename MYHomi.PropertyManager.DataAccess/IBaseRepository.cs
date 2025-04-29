using MongoDB.Driver;

namespace MyHomi.PropertyManager.DataAccess.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken);
        Task<List<TEntity>> BulkCreate(List<TEntity> lstTEntity, CancellationToken cancellationToken);
        Task Update(FilterDefinition<TEntity> filter, TEntity obj, CancellationToken cancellationToken);
        Task Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> obj, CancellationToken cancellationToken);
        Task BulkUpdate(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken);
        Task Delete(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);
        Task Delete(string id, CancellationToken cancellationToken);
        Task BulkDelete(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);
        Task<TEntity> GetByID(string id, CancellationToken cancellationToken);
        Task<List<TEntity>> Get(CancellationToken cancellationToken);
        Task<TEntity> GetByID(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAllByID(FilterDefinition<TEntity> filter, CancellationToken cancellationToken);
    }
}
