using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.API.Controllers
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

        [Route("GetSlide")]
        [HttpGet]
        public PagedResult<Slide> GetSlides([FromQuery] SlidePagingManageGetRequest request)
        {
            return _slideService.GetSlides(request);
        }

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromBody] SlideCreateRequest request)
        {
            try
            {
                bool result = _slideService.Create(request);
                return new ApiSuccessResult<string>("Created successfully");
            }
            catch(Exception ex) 
            {
                return new ApiSuccessResult<string>("Failed to create");
            }
            
        }

        [Route("Update")]
        [HttpPut]
        public ApiResult<string> Update([FromBody] SlideUpdateRequest request)
        {
            try
            {
                bool result = _slideService.Update(request);
                return new ApiSuccessResult<string>("Updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<string>("Failed to update");
            }

        }
    }
}
