using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Features.ProductFeature;
using Thegioididong.Service.Features;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private IProductFeatureService _productFeatureService;
        public ProductFeatureController(IProductFeatureService productFeatureService)
        {
            this._productFeatureService = productFeatureService;
        }

        [Route("GetProductFeaturesHome")]
        [HttpGet]
        public List<ProductFeatureHome> GetProductFeaturesHome()
        {
            return _productFeatureService.GetProductFeaturesHome();
        }
    }
}
