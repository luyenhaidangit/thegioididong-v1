using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Sales.SaleInvoices
{
    public class CustomerPublicCreateRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }
    }

    public class SaleInvoiceDetailPublicCreateRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class SaleInvoicePublicCreateRequest
    {
        public CustomerPublicCreateRequest Customer { get; set; }

        public string Andress { get; set; }

        public string Note { get; set;}

        public int DeliveryMethod { get; set; }

        public int PaymentMethod { get; set; }

        public int Status { get; set; }

        public SaleInvoiceDetailPublicCreateRequest SaleInvoiceDetails { get; set; }
    }
}
