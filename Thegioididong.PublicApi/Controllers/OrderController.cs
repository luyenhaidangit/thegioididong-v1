using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Sales.Orders;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public ApiResult<OrderPublicCreateResult> Create(OrderPublicCreateRequest request)
        {
            try
            {
                OrderPublicCreateResult result = _orderService.Create(request);
                return new ApiSuccessResult<OrderPublicCreateResult>(201,"Tạo sản phẩm thành công!",result);
            }
            catch (Exception ex)
            {
                return new ApiSuccessResult<OrderPublicCreateResult>(null,"Tạo sản phẩm thất bại!");
            }
        }

        //[Route("Create")]
        //[HttpPost]
        //public ApiResult<string> Create([FromBody] ProductManageCreateRequest request)
        //{
        //    try
        //    {
        //        bool result = _productService.Create(request);
        //        return new ApiSuccessResult<string>("Tạo sản phẩm thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiSuccessResult<string>("Tạo sản phẩm thất bại!");
        //    }
        //}
    }
}
