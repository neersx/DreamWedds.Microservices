using AutoMapper;
using DreamWedds.Services.TemplatesAPI.Entities;
using DreamWedds.Services.TemplatesAPI.Models;
using DreamWedds.Services.TemplatesAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.TemplatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateRepository _repository;
        private readonly ILogger<TemplatesController> _logger;
        private readonly IMapper _mapper;

        public TemplatesController(ITemplateRepository repository, ILogger<TemplatesController> logger,
             IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TemplateMaster>>> GetTemplatesList()
        {
            var templates = await _repository.GetTemplatesList();
            return Ok(templates);
        }
    }
}
