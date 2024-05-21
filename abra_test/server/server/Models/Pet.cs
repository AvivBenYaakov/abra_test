using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace server.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;

        [BsonElement("color")]
        public string Color { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age {  get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; }
    }
}
