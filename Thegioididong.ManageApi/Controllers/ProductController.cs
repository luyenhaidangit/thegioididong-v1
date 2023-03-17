using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.ManageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [Route("Get")]
        [HttpGet]
        public PagedResult<ProductManageGetResult> Get([FromQuery] ProductPagingManageGetRequest request)
        {
            return _productService.Get(request);
        }

        [Route("Create")]
        [HttpPost]
        public ApiResult<string> Create([FromBody] ProductManageCreateRequest request)
        {
            try
            {
                bool result = _productService.Create(request);
                return new ApiSuccessResult<string>("Tạo sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Tạo sản phẩm thất bại!");
            }
        }

        [Route("Update")]
        [HttpPut]
        public ApiResult<string> Update([FromBody] ProductManageUpdateRequest request)
        {
            try
            {
                bool result = _productService.Update(request);
                return new ApiSuccessResult<string>("Cập nhật sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<string>("Cập nhật sản phẩm thất bại!");
            }
        }
    }
}
