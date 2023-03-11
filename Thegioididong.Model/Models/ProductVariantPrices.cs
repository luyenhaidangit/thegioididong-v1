using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.Models
{
    public class ProductVariantPrices
    {
        public int Id { get; set; }

        public int ProductVariantId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
