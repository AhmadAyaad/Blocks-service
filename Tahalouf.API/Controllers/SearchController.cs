using Microsoft.AspNetCore.Mvc;
using Tahalouf.API.DTOS;
using Tahalouf.App.IService;

namespace Tahalouf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpPost]
        public IActionResult Search(KeywordDTO keywordDTO)
        {
            var searchResults = _searchService.SearchByKeyWord(keywordDTO.Keyword);
            return Ok(searchResults);
        }
    }
}
