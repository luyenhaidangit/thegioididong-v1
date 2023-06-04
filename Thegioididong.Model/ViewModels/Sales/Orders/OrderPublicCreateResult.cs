using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Sales.Orders
{
    public class OrderPublicCreateResult
    {
        public int OrderId { get; set; }

        public double Amount { get; set; } 

        public string? Note { get; set; }

        public int? PaymentMethod { get; set; }

        public string? DirectUrl { get; set; }
    }
}
