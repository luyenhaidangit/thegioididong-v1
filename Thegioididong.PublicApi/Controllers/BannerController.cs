using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;
using Thegioididong.Service.CMS;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            this._bannerService = bannerService;
        }

        [Route("banner-main")]
        [HttpGet]
        public BannerPublicGetResult GetBannerMain()
        {
            return _bannerService.GetBannerMain();
        }

        [Route("banner-topzone")]
        [HttpGet]
        public BannerPublicGetResult GetBannerTopzone()
        {
            return _bannerService.GetBannerTopzone();
        }
    }
}
