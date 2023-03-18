using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
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
        public SlideController(ISlideService slideService)
        {
            this._slideService = slideService;
        }

        [Route("GetSlideHeaderTop")]
        [HttpGet]
        public SlidePublicGetResult GetSlideHeaderTop()
        {
            return _slideService.GetSlideHeaderTop();
        }

        [Route("GetSlideBigCampaign")]
        [HttpGet]
        public SlidePublicGetResult GetSlideBigCampaign()
        {
            return _slideService.GetSlideBigCampaign();
        }
    }
}
