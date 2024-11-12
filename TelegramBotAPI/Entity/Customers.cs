using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Specialized;

namespace TelegramBotAPI.Entity
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("customerName"), BsonRepresentation(BsonType.String)]
        public String CustomerName { get; set; }

        [BsonElement("phoneNumber"), BsonRepresentation(BsonType.Int32)]
        public int PhoneNumber { get; set; }

        [BsonElement("language"), BsonRepresentation(BsonType.String)]
        public string Language { get; set; }

        [BsonElement("signed"), BsonRepresentation(BsonType.Boolean)]
        public bool Signed { get; set; }

        [BsonElement("registrationDate"), BsonRepresentation(BsonType.DateTime)]
        public DateTime RegistrationDate { get; set; }

    }
}
