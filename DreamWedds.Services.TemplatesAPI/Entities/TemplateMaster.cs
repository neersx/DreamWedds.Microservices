using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamWedds.Services.TemplatesAPI.Entities
{
    public class TemplateMaster
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; } // Wedding, Invitation, Engagement, BirthDay, Email
        public int Status { get; set; }
        public string Content { get; set; }
   
        public string Subject { get; set; }
   
        public string Tags { get; set; }

        public string TemplateUrl { get; set; }

        public string TemplateFolderPath { get; set; }
   
        public string ThumbnailImageUrl { get; set; }

        public string TagLine { get; set; }
        public decimal? Cost { get; set; }
      
        public string AuthorName { get; set; }

        public string AboutTemplate { get; set; }
   
        public string Features { get; set; }
 
        public string TemplateCode { get; set; }
        public string TemplateSettings { get; set; }
        public string TemplateTags { get; set; }
        public ICollection<MetaTags> MetaTags { get; set; }
    }
}
