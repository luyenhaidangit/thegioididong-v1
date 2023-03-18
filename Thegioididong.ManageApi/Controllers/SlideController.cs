using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.Products;
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

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromBody] SlideCreateRequest request)
        {
            try
            {
                bool result = _slideService.Create(request);
                return new ApiSuccessResult<string>("Tạo slide thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Tạo slide thất bại!");
            }
        }

        [Route("Update")]
        [HttpPut]
        public ApiResult<string> Update([FromBody] SlideUpdateRequest request)
        {
            try
            {
                bool result = _slideService.Update(request);
                return new ApiSuccessResult<string>("Cập nhật slide thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Cập nhật slide thất bại!");
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public ApiResult<string> Delete([FromQuery] int id)
        {
            try
            {
                bool result = _slideService.Delete(id);
                return new ApiSuccessResult<string>("Xóa slide thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Xóa slide thất bại!");
            }
        }
    }
}
