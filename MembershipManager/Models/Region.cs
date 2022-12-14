using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MembershipManager.Models
{
    public class Region : Common
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
