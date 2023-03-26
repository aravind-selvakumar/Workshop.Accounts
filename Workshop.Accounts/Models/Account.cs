using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Workshop.Accounts.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserNumber")]
        [JsonPropertyName("UserNumber")]
        public string UserNumber { get; set; } = null!;

        [BsonElement("AccountBalance")]
        [JsonPropertyName("AccountBalance")]
        public int AccountBalance { get; set; }

        [BsonElement("AccountStatus")]
        [JsonPropertyName("AccountStatus")]
        public string AccountStatus { get; set; } = string.Empty;

        [BsonElement("AccountType")]
        [JsonPropertyName("AccountType")]
        public string AccountType { get; set; } = string.Empty;
    }
}
