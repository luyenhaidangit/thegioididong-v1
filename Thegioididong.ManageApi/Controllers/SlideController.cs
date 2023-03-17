using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.ManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private ISlideService _slideService;
        public SlideController(ISlideService slideService)
        {
            this._slideService = slideService;
        }

        [Route("Get")]
        [HttpGet]
        public PagedResult<SlideManageGetResult> Get([FromQuery] SlidePagingManageGetRequest request)
        {
            return _slideService.GetSlides(request);
        }
    }
}
