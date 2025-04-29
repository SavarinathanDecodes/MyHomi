namespace MyHomi.PropertyManager.Domain.Model.Entity
{
    public class BsonCollectionAttribute : Attribute
    {
        public virtual string CollectionName { get; private set; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
