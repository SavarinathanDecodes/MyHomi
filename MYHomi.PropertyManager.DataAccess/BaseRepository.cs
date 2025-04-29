using MongoDB.Bson;
using MongoDB.Driver;
using MyHomi.PropertyManager.DataAccess.Interface;
using MyHomi.PropertyManager.Domain.Model.Entity;

namespace MyHomi.PropertyManager.DataAccess
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IMongoEntity
    {

        #region Private members

        private readonly IUnitOfWork _mongoContext;
        private readonly IMongoCollection<TEntity> _dbCollection;

        #endregion

        #region Constractor

        public BaseRepository(IUnitOfWork context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>();
        }

        #endregion


        #region Public Methods

        public async Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }

            try
            {
                using (var transaction = _mongoContext.GetCurrentTransactionSession<IClientSessionHandle>())
                {
                    BeforeInsert(obj);
                    switch (transaction)
                    {
                        case null:
                            await _dbCollection.InsertOneAsync(obj, cancellationToken: cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await _dbCollection.InsertOneAsync(transaction, obj, cancellationToken: cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return obj;
        }

        public async Task<List<TEntity>> BulkCreate(List<TEntity> listTEntity, CancellationToken cancellationToken)
        {
            if (listTEntity.Count == 0)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            using (var transaction = _mongoContext.GetCurrentTransactionSession<IClientSessionHandle>())
            {
                listTEntity.ForEach(BeforeInsert);
                switch (transaction)
                {
                    case null:
                        await _dbCollection.InsertManyAsync(listTEntity, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                    default:
                        await _dbCollection.InsertManyAsync(transaction, listTEntity, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                }
            }
            return listTEntity;
        }

        public virtual async Task Update(FilterDefinition<TEntity> filter, TEntity obj, CancellationToken cancellationToken)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }

            using (var transaction = _mongoContext.GetCurrentTransactionSession<IClientSessionHandle>())
            {
                obj = BeforeUpdate(obj);
                switch (transaction)
                {
                    case null:
                        await _dbCollection.ReplaceOneAsync(filter, obj, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                    default:
                        await _dbCollection.ReplaceOneAsync(transaction, filter, obj, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                }
            }

        }


        public virtual async Task Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken)
        {


            using (var transaction = _mongoContext.GetCurrentTransactionSession<IClientSessionHandle>())
            {

                switch (transaction)
                {
                    case null:
                        await _dbCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                    default:
                        await _dbCollection.UpdateOneAsync(transaction, filter, update, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                }
            }
        }

        public virtual async Task BulkUpdate(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken)
        {

            using (var transaction = _mongoContext.GetCurrentTransactionSession<IClientSessionHandle>())
            {

                switch (transaction)
                {
                    case null:
                        await _dbCollection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                    default:
                        await _dbCollection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken).ConfigureAwait(false);
                        break;
                }
            }
        }

        public async Task<TEntity> GetByID(string id, CancellationToken cancellationToken)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter, cancellationToken: cancellationToken).Result.FirstOrDefaultAsync();
        }

        public async Task Delete(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
        {

            await _dbCollection.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);

        }
        public async Task Delete(string id, CancellationToken cancellationToken)
        {
            var objectId = new ObjectId(id);
            await _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId), cancellationToken: cancellationToken);

        }

        public async Task BulkDelete(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
        {
            await _dbCollection.DeleteManyAsync(filter, cancellationToken: cancellationToken);
        }

        public async Task<List<TEntity>> Get(CancellationToken cancellationToken)
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }
        public async Task<TEntity> GetByID(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
        {
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<TEntity>> GetAllByID(FilterDefinition<TEntity> filter, CancellationToken cancellationToken)
        {
            var all = await _dbCollection.FindAsync(filter, cancellationToken: cancellationToken);
            return await all.ToListAsync();
        }


        public TEntity BeforeUpdate(TEntity entity)
        {
            entity.UpdatedBy = "test";
            entity.UpdatedOn = DateTime.Now;
            return entity;
        }
        public void BeforeInsert(TEntity entity)
        {
            entity.CreatedBy = "test";
            entity.CreatedOn = DateTime.Now;
        }

        #endregion
    }
}
