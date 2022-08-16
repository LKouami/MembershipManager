using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace MembershipManager.Models
{
    [CollectionName("Users")]
    public class User : MongoIdentityUser<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; }
        [BsonElement("Password")]
        public string? Password { get; set; }


    }
}
