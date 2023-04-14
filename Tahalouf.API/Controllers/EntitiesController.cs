using Microsoft.AspNetCore.Mvc;
using Tahalouf.App.IService;

namespace Tahalouf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntitiesController(IEntityService entityService)
        {
            _entityService = entityService;
        }
        [HttpGet]
        public IActionResult GetEntitiesWithAttributes()
        {
            var entitiesWithAttributes = _entityService.GetEntitesWithAttributes();
            return Ok(entitiesWithAttributes);
        }
    }
}
