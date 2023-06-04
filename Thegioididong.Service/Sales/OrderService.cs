using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Common.Constants;
using Thegioididong.Data.Repositories;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Sales.Orders;
using Thegioididong.Model.ViewModels.Sales.Payment;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface IOrderService
    {
        // Manage


        // Public
        OrderPublicCreateResult Create(OrderPublicCreateRequest request);

        PagedResult<Order> GetOrders(OrderCustomerPublicGetRequest request);

        OrderViewModel GetById(int id);

    }
    public partial class SaleInvoiceService : IOrderService
    {
        private IOrderRepository _SaleInvoiceRepository;
        private IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;

        public SaleInvoiceService(IOrderRepository SaleInvoiceRepository, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this._SaleInvoiceRepository = SaleInvoiceRepository;
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }


        public OrderPublicCreateResult Create(OrderPublicCreateRequest request)
        {
            OrderPublicCreateResult orderPublicCreateResult = _SaleInvoiceRepository.Create(request);

            if (orderPublicCreateResult.PaymentMethod == 1)
            {
                string url = "http://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
                string returnUrl = "https://localhost:3000/payment";
                string tmnCode = "W1S76XUC";
                string hashSecret = "NAAAEZRQYLYHBERCVOOKWVLYPMJWNFAE";

                PaymentViewModel pay = new PaymentViewModel();

                pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
                pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
                pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
                pay.AddRequestData("vnp_Amount", (100).ToString()); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
                pay.AddRequestData("vnp_BankCode", "NCB"); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
                pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
                pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
                pay.AddRequestData("vnp_IpAddr", "13.160.92.202");
                pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
                pay.AddRequestData("vnp_OrderInfo", "ok"); //Thông tin mô tả nội dung thanh toá
                                                                                   //pay.AddRequestData("vnp_OrderNameCustomer", model.Customer.Name); //Thông tin mô tả nội dung thanh toán
                pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
                pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
                pay.AddRequestData("vnp_TxnRef", (1006200210062002).ToString()); //mã hóa đơn

                string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

                orderPublicCreateResult.DirectUrl = paymentUrl;
            }

            return orderPublicCreateResult;
        }

        #region Manage


        #endregion

        #region Public
        public PagedResult<Order> GetOrders(OrderCustomerPublicGetRequest request)
        {
            return _SaleInvoiceRepository.GetOrders(request);
        }

        public OrderViewModel GetById(int id)
        {
            return _SaleInvoiceRepository.GetById(id);
        }
        #endregion
    }
}
