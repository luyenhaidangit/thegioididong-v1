using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductItemCardDefault
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public bool IsInterest { get; set; }

        public string? ShortDescription { get; set; }

        public BadgeProductPublicGetResult? BadgeProduct { get; set; }

        public decimal OriginalPrice { get; set; }

        public double DiscountedPrice { get; set; }

        public int DiscountPercent { get; set; }

        public double StarRating { get; set; }

        public int ReviewCount { get; set; }
    }
}
