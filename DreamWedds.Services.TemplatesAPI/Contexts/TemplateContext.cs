using DreamWedds.Services.TemplatesAPI.Data;
using DreamWedds.Services.TemplatesAPI.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Contexts
{
    public class TemplateContext : ITemplateContext
    {
       
        public IMongoCollection<TemplateMaster> Templates { get; }

        public TemplateContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));
            Templates = database.GetCollection<TemplateMaster>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            TemplateContextSeedData.SeedData(Templates);
        }
    }
}
