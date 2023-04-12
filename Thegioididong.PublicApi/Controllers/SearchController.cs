using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Plugins.Search;
using Thegioididong.Service;
using Thegioididong.Service.Plugins;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        [Route("suggest")]
        [HttpGet]
        public SearchSuggestPublicGetResult GetSearchSuggest([FromQuery] string keyword)
        {
            return this._searchService.GetSearchSuggest(keyword);
        }
    }
}
