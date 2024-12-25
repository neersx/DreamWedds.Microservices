using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DreamWedds.Services.TemplatesAPI.Entities
{
    public class MetaTags
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string KeyValue { get; set; }
        public string? TagFor { get; set; }
    }
}
