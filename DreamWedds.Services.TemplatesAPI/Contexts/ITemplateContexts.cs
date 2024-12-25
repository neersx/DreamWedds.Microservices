using DreamWedds.Services.TemplatesAPI.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Contexts
{
    public interface ITemplateContext
    {
        IMongoCollection<TemplateMaster> Templates { get; }
    }
}
