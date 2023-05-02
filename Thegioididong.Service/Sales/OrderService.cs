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
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface IOrderService
    {
        // Manage


        // Public
        OrderPublicCreateResult Create(OrderPublicCreateRequest request);

    }
    public partial class SaleInvoiceService : IOrderService
    {
        private IOrderRepository _SaleInvoiceRepository;

        public SaleInvoiceService(IOrderRepository SaleInvoiceRepository)
        {
            this._SaleInvoiceRepository = SaleInvoiceRepository;
        }

        public OrderPublicCreateResult Create(OrderPublicCreateRequest request)
        {
            return _SaleInvoiceRepository.Create(request);
        }

        #region Manage


        #endregion

        #region Public



        #endregion
    }
}
