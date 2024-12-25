using DreamWedds.Services.TemplatesAPI.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Data
{
    public class TemplateContextSeedData
    {
        public static void SeedData(IMongoCollection<TemplateMaster> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(AddTemplates());
            }
        }

        private static IEnumerable<TemplateMaster> AddTemplates()
        {
            return new List<TemplateMaster>();
        }
    }
}
