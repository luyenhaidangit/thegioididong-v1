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
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;
using Thegioididong.Service.Common;

namespace Thegioididong.Service
{
    public partial interface ISaleInvoiceService
    {
        // Manage


        // Public
        bool CreateSaleOrder(SaleInvoicePublicCreateRequest request);

    }
    public partial class SaleInvoiceService : ISaleInvoiceService
    {
        private ISaleInvoiceRepository _SaleInvoiceRepository;

        public SaleInvoiceService(ISaleInvoiceRepository SaleInvoiceRepository)
        {
            this._SaleInvoiceRepository = SaleInvoiceRepository;
        }

        public bool CreateSaleOrder(SaleInvoicePublicCreateRequest request)
        {
            return _SaleInvoiceRepository.CreateSaleOrder(request);
        }

        #region Manage


        #endregion

        #region Public



        #endregion
    }
}
