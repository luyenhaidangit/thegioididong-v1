using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;
using Thegioididong.Service;

namespace Thegioididong.PublicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ISaleInvoiceService _saleInvoiceService;
        public OrderController(ISaleInvoiceService saleInvoiceService)
        {
            this._saleInvoiceService = saleInvoiceService;
        }

        [Route("CreateOrder")]
        [HttpPost]
        public bool CreateOrder(SaleInvoicePublicCreateRequest request)
        {
            return _saleInvoiceService.CreateSaleOrder(request);
        }

        [Route("GetListOrderByUser")]
        [HttpPost]
        public bool GetListOrderByUser(SaleInvoicePublicCreateRequest request)
        {
            return _saleInvoiceService.CreateSaleOrder(request);
        }

        [Route("GetOrderByUser")]
        [HttpPost]
        public bool GetOrderByUser(SaleInvoicePublicCreateRequest request)
        {
            return _saleInvoiceService.CreateSaleOrder(request);
        }
    }
}
