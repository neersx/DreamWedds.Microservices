using DreamWedds.Services.TemplatesAPI.Entities;
using DreamWedds.Services.TemplatesAPI.Models;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Repository
{
    public interface ITemplateRepository
    {
        Task<IEnumerable<TemplateMaster>> GetTemplatesList();
        Task<TemplateResponseModel> GetTemplateById(int id);
        Task<TemplateResponseModel> GetEmailTemplateByCode(string code);
        Task<string> GetEmailContentByCode(string code);
        IMongoCollection<TemplateResponseModel> GetTemplatesByType(int id);

    }
}
