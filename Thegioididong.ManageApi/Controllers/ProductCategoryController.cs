using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.ManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("GetProductCategories")]
        [HttpGet]
        public PagedResult<ProductCategory> GetProductCategories([FromQuery] ProductCategoryPagingManageGetRequest request)
        {
            return _productCategoryService.GetProductCategories(request);
        }

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromForm] ProductCategoryCreateRequest request)
        {
            try
            {
                bool result = _productCategoryService.Create(request);
                return new ApiSuccessResult<string>("Tạo mới loại sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Tạo mới loại sản phẩm thất bại!");
            }
        }

        [Route("Update")]
        [HttpPut]
        public ApiResult<string> Update([FromForm] ProductCategoryUpdateRequest request)
        {
            try
            {
                bool result = _productCategoryService.Update(request);
                return new ApiSuccessResult<string>("Cập nhật loại sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Cập nhật loại sản phẩm thất bại!");
            }
        }
    }
}
