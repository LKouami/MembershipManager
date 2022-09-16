using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MembershipManager.Models
{
    public class Member : Common
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? NumCard { get; set; }
        [BsonElement("Cni")]
        [JsonPropertyName("Cni")]
        public string? NumCni { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Gender { get; set; }
        public string? Birthdate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Occupation { get; set; }
        public string? Province { get; set; }
        public string? SubscriptionType { get; set; }
        public string? SubscriptionDate { get; set; }
        public string? CommuneId { get; set; }
        public string? Contact { get; set; }
        public string? MembershipNum { get; set; }
        public string? QrCodeRef { get; set; }

    }

}
