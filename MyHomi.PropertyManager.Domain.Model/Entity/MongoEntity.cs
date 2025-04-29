using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyHomi.PropertyManager.Domain.Model.Entity
{
    [BsonIgnoreExtraElements(true, Inherited = true)]
    public abstract class MongoEntity : IMongoEntity
    {
        #region Private members

        private DateTime _createdOn;

        #endregion

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("Created_On")]
        public DateTime CreatedOn
        {
            get
            {
                if (_createdOn == null || _createdOn == DateTime.MinValue)
                    _createdOn = DateTime.Now;
                return _createdOn;
            }
            set
            {
                _createdOn = value;
            }
        }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("Updated_On")]
        public DateTime? UpdatedOn { get; set; } = DateTime.Now;

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Created_By")]
        public string CreatedBy { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Updated_By")]
        public string UpdatedBy { get; set; } = string.Empty;

    }

    public interface IMongoEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
