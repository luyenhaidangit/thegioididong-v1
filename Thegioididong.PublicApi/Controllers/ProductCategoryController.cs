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
        public PagedResult<CategoryNavigationGetResult> GetProductCategoryNavigation()
        {
            return _productCategoryService.GetProductCategoryNavigation();
        }
    }
}
