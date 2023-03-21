using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductDailySuggest
    {
        public List<ProductItemCardDefault> LatestProducts { get; set; }

        public List<ProductItemCardDefault> PopularProducts { get; set; }

        public List<ProductItemCardDefault> SellingProducts { get; set; }

        public List<ProductItemCardDefault> TopRatedProducts { get; set; }
    }
}
