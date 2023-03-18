using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.CMS.Banners;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;
using Thegioididong.Service.CMS;

namespace Thegioididong.ManageApi.Controllers
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

        [Route("Get")]
        [HttpGet]
        public PagedResult<BannerManageGetResult> Get([FromQuery] BannerPagingManageGetRequest request)
        {
            return _bannerService.Get(request);
        }

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromBody] BannerManageCreateRequest request)
        {
            try
            {
                bool result = _bannerService.Create(request);
                return new ApiSuccessResult<string>("Tạo banner thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Tạo banner thất bại!");
            }
        }

        [Route("Update")]
        [HttpPut]
        public ApiResult<string> Update([FromBody] BannerManageUpdateRequest request)
        {
            try
            {
                bool result = _bannerService.Update(request);
                return new ApiSuccessResult<string>("Cập nhật banner thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Cập nhật banner thất bại!");
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public ApiResult<string> Delete([FromQuery] int id)
        {
            try
            {
                bool result = _bannerService.Delete(id);
                return new ApiSuccessResult<string>("Xóa banner thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Xóa banner thất bại!");
            }
        }
    }
}
