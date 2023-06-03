using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.News;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;
using Thegioididong.Service.CMS;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }

        [HttpGet]
        public PagedResult<News> Get([FromQuery]NewsPaingPublicGetRequest request)
        {
            return _newsService.Get(request);
        }

        [Route("Home")]
        [HttpGet]
        public List<News> GetNewsHome()
        {
            return _newsService.GetNewsHome();
        }

        [HttpGet("{id}")]
        public News GetDetail(int id)
        {
            return _newsService.GetById(id);
        }
    }
}
