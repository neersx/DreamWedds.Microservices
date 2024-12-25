using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamWedds.Services.TemplatesAPI.Models
{

    public class TemplateResponseModel
    {
        [BsonId] // Specifies the primary key for the BSON document.
        [BsonRepresentation(BsonType.ObjectId)] // Indicates that this is an ObjectId in BSON.
        public string Id { get; set; }

        [BsonElement("name")] // Specifies the BSON field name.
        [BsonRequired] // Marks the field as required.
        public string Name { get; set; }

        [BsonElement("type")]
        public int Type { get; set; }

        [BsonElement("typeValue")]
        public string TypeValue { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("subject")]
        public string Subject { get; set; }

        [BsonElement("tags")]
        public string Tags { get; set; }

        [BsonElement("templateCode")]
        public string? TemplateCode { get; set; }

        [BsonElement("templateUrl")]
        public string TemplateUrl { get; set; }

        [BsonElement("templateFolderPath")]
        public string TemplateFolderPath { get; set; }

        [BsonElement("thumbnailImageUrl")]
        public string ThumbnailImageUrl { get; set; }

        [BsonElement("tagLine")]
        public string TagLine { get; set; }

        [BsonElement("cost")]
        public decimal? Cost { get; set; }

        [BsonElement("features")]
        public string Features { get; set; }

        [BsonElement("authorName")]
        public string AuthorName { get; set; }

        [BsonElement("aboutTemplate")]
        public string AboutTemplate { get; set; }
    }

}
