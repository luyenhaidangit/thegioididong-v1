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
    public class CouponController : ControllerBase
    {
        private ICounponService _newsService;
        public CouponController(ICounponService newsService)
        {
            this._newsService = newsService;
        }

        [HttpGet]
        public List<Coupon> Get()
        {
            return _newsService.Get();
        }

        [HttpGet("{id}")]
        public Coupon GetById(int id)
        {
            return _newsService.GetById(id);
        }
    }
}
