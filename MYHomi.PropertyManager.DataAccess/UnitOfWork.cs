using MongoDB.Driver;
using MyHomi.PropertyManager.Domain.Model.Entity;
using MyHomi.PropertyManager.Utility.Config;
using System.Reflection;

namespace MyHomi.PropertyManager.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private members

        IMongoClient MongoClient = null!;
        IClientSessionHandle Session = null!;
        IMongoDatabase MongoDatabase = null!;

        #endregion

        #region Constractor

        public UnitOfWork(IAppSettings appSettings)
        {
            MongoClient = new MongoClient(appSettings.ConnectionString);
            MongoDatabase = MongoClient.GetDatabase(appSettings.DatabaseName);
        }

        #endregion

        #region Public methods

        public IMongoCollection<T> GetCollection<T>()
        {
            var attribute = typeof(T).GetTypeInfo().GetCustomAttribute<BsonCollectionAttribute>();
            var CollectionName = attribute?.CollectionName ?? typeof(T).Name;
            return MongoDatabase.GetCollection<T>(CollectionName);
        }

        public object GetSessionId()
        {
            return Session.ServerSession.Id;
        }

        public TTransactionSessionType GetCurrentTransactionSession<TTransactionSessionType>() => (TTransactionSessionType)Session;


        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
