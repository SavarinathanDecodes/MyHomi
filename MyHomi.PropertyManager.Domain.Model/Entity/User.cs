using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyHomi.PropertyManager.Domain.Model.Entity
{
    [BsonCollection("User")]
    internal abstract class User : MongoEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [BsonElement("last_name")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

    }
}
