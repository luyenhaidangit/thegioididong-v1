using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductPriceManageCreateRequest
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public DateTime? PriceStartDate { get; set; }

        public DateTime? PriceEndDate { get; set;}
    }
}
