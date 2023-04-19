using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
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

        [Route("daily-suggest")]
        [HttpGet]
        public ProductDailySuggest GetProductDailySuggest()
        {
            return _productService.GetProductDailySuggest();
        }

        [Route("hot-deal")]
        [HttpGet]
        public List<ProductItemCardDefault> GetProductsHotDeal()
        {
            return _productService.GetProductsHotDeal();
        }

        [Route("features")]
        [HttpGet]
        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            return _productService.GetProductFeaturesHome();
        }

        [Route("GetProductDetailPage")]
        [HttpGet]
        public ProductDetailPage GetProductDetailPage(int id)
        {
            return _productService.GetProductDetailPage(id);
        }

        [HttpPost]
        public List<ProductItemCardDefault> GetProductsProductCategoryDetailPage([FromBody]ProductPaingPublicGetRequest request)
        {
            return _productService.GetProductsProductCategoryDetailPage(request);
        }
    }
}
