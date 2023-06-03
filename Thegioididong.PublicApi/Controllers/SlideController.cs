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

        [Route("header-top")]
        [HttpGet]
        public SlidePublicGetResult GetSlideHeaderTop()
        {
            return _slideService.GetSlideHeaderTop();
        }

        [Route("big-campaign")]
        [HttpGet]
        public SlidePublicGetResult GetSlideBigCampaign()
        {
            return _slideService.GetSlideBigCampaign();
        }

        [Route("option-promo")]
        [HttpGet]
        public SlidePublicGetResult GetSlideOptionPromo()
        {
            return _slideService.GetSlideOptionPromo();
        }

        [Route("shopping-trends")]
        [HttpGet]
        public SlidePublicGetResult GetSlideShoppingTrends()
        {
            return _slideService.GetSlideShoppingTrends();
        }

        [Route("discount-pay-online")]
        [HttpGet]
        public SlidePublicGetResult GetSlideDiscountPayOnline()
        {
            return _slideService.GetSlideDiscountPayOnline();
        }
    }
}
