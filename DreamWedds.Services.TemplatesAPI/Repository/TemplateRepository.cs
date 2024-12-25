using DreamWedds.Services.TemplatesAPI.Contexts;
using DreamWedds.Services.TemplatesAPI.Entities;
using DreamWedds.Services.TemplatesAPI.Models;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Repository
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly ITemplateContext _context;
        public TemplateRepository(ITemplateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<TemplateMaster>> GetProducts()
        {
            return await _context
                            .Templates
                            .Find(p => p.Status == 1)
                            .ToListAsync();
        }
        public IMongoCollection<TemplateMaster> GetTemplateMasterList => throw new NotImplementedException();

        public Task<string> GetEmailContentByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateResponseModel> GetEmailTemplateByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Task<TemplateResponseModel> GetTemplateById(int id)
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<TemplateResponseModel> GetTemplatesByType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
