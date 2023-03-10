using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thegioididong.Model.ViewModels.Catalog.Products
{
    public class ProductDailySuggest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameBadgeProduct { get; set; }

        public string ImageBadgeProduct { get; set; }

        public string BackgroundColorBadgeProduct { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public int DiscountPercent { get; set; }

        public double StarRating { get; set; }

        public int ReviewCount { get; set; }
    }

    public class ProductDailySuggestGetResult
    {
        public IEnumerable<ProductDailySuggest> LatestProducts { get; set; }

        public IEnumerable<ProductDailySuggest> PopularProducts { get; set; }

        public IEnumerable<ProductDailySuggest> BestSellingProducts { get; set; }

        public IEnumerable<ProductDailySuggest> TopRatedProducts { get; set; }
    }
}
