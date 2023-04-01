using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
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

        [Route("GetProductCategoryNavigation")]
        [HttpGet]
        public List<ProductCategoryHomeNavigation> GetProductCategoryHomeNavigation()
        {
            return _productCategoryService.GetProductCategoryNavigation();
        }

        [Route("GetProductCategoriesFeaturesHome")]
        [HttpGet]
        public List<ProductCategoryFeatureHome> GetProductCategoriesFeaturesHome()
        {
            return _productCategoryService.GetProductCategoriesFeaturesHome();
        }

        [Route("GetProductCategoryTopBanner")]
        [HttpGet]
        public ApiResult<ProductCategoryTopBannerGetResult> GetProductCategoryTopBanner(int id)
        {
            ProductCategoryTopBannerGetResult result = _productCategoryService.GetProductCategoryTopBanner(id);
            if (result == null)
            {
                return new ApiSuccessResult<ProductCategoryTopBannerGetResult>(204,null,result);
            }
            return new ApiSuccessResult<ProductCategoryTopBannerGetResult>(result);
        }

        [Route("GetProductCategoryBoxFilter")]
        [HttpGet]
        public ProductCategoryBoxFilterGetResult GetProductCategoryBoxFilter(int id)
        {
            return _productCategoryService.GetProductCategoryBoxFilter(id);
        }
    }
}
