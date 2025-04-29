using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyHomi.PropertyManager.Domain.Model.Entity
{
    [BsonCollection("Property")]
    public class Property : MongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("area")]
        public int Area { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("price")]
        public int Price { get; set; }
    }
}
