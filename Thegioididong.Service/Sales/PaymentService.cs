using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;

namespace Thegioididong.Service.Sales
{
    public partial interface ISaleInvoiceService
    {
        // Manage


        // Public
        bool CreateSaleOrder(SaleInvoicePublicCreateRequest request);

    }
}
