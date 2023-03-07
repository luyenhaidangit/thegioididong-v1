using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private ISlideService _slideService;
        public SlideController(ISlideService SlideService)
        {
            this._slideService = SlideService;
        }

        [Route("GetSlides")]
        [HttpGet]
        public PagedResult<SlidePublicGetResult> GetSlides([FromQuery] SlidePagingPublicGetRequest request)
        {
            return _slideService.GetSlides(request);
        }
    }
}
