using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
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

        [Authorize()]
        [HttpPost]
        public PagedResult<OrderCustomerPublicGetResult> Get([FromBody] OrderCustomerPublicGetRequest request)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null)
            {
                // user is not authenticated
                throw new Exception("Không nhận được username hợp lệ!");
            }

            var userId = userIdClaim.Value;
            request.Username = userId;

            return _orderService.GetOrders(request);
        }
    }
}
