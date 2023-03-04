using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private ISlideService _slideService;
        public SlideController(ISlideService SlideService)
        {
            this._slideService = SlideService;
        }

        #region Manage

        [Route("admin/[controller]/GetSlides")]
        [Authorize]
        [HttpGet]
        public PagedResult<Slide> GetSlides([FromQuery] SlidePagingManageGetRequest request)
        {
            return _slideService.GetSlides(request);
        }

        [Route("admin/[controller]/Create")]
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

        [Route("admin/[controller]/Update")]
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

        [Route("admin/[controller]/Delete")]
        [HttpDelete]
        public ApiResult<string> Update([FromQuery] int id)
        {
            try
            {
                bool result = _slideService.Delete(id);
                return new ApiSuccessResult<string>("Deleed successfully");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<string>("Failed to delete");
            }
        }

        #endregion

        #region Public

        [Route("[controller]/GetSlides")]
        [HttpGet]
        public PagedResult<Slide> GetSlides(SlidePagingPublicGetRequest request)
        {
            return _slideService.GetSlides(request);
        }

        #endregion
    }
}
