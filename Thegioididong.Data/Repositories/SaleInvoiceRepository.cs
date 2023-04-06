using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;

namespace Thegioididong.Data.Repositories
{
    public partial interface ISaleInvoiceRepository
    {
        // Manage


        // Public
        public bool CreateSaleOrder(SaleInvoicePublicCreateRequest request);
       
    }
    public partial class SaleInvoiceRepository : ISaleInvoiceRepository
    {
        private IDatabaseHelper _dbHelper;
        public SaleInvoiceRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool CreateSaleOrder(SaleInvoicePublicCreateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_saleinvoice_createsaleorder",
                "@request", requestJson);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Manage


        #endregion
    }
}
