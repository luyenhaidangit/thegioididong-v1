using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Catalog.Products;
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

        public ProductDailySuggestGetResult GetProductDailySuggest()
        {
            return _productService.GetProductDailySuggest();
        }
    }
}
